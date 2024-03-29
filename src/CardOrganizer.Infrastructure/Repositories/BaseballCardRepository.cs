using System.IO;
using System.Text.Json;
using CardOrganizer.Application.Models;
using CardOrganizer.Domain;
using CardOrganizer.Domain.Exceptions;
using CardOrganizer.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CardOrganizer.Infrastructure.Repositories;

public class BaseballCardRepository : IBaseballCardRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
    private readonly IFileService _fileService;
    
    public BaseballCardRepository(IDbContextFactory<ApplicationDbContext> contextFactory, IFileService fileService)
    {
        _contextFactory = contextFactory;
        _fileService = fileService;
    }
    
    public BaseballCard GetById(int baseballCardId)
    {
        var dbContext = _contextFactory.CreateDbContext();

        var baseballCard = dbContext.BaseballCards
            .Include(b => b.Brand)
            .FirstOrDefault(b => b.BaseballCardId == baseballCardId);

        if (baseballCard is null)
        {
            throw new ObjectNotFoundException("Unable to find the specified brand");
        }

        var card = BaseballCard.FromDto(baseballCard);
        
        if (card.FrontImageUrl != string.Empty)
        {
            card.FrontImageData = _fileService.GetImage(Constants.CardType.Baseball, card.BaseballCardId);
        }
        
        if (card.BackImageUrl != string.Empty)
        {
            card.BackImageData = _fileService.GetImage(Constants.CardType.Baseball, card.BaseballCardId, Constants.CardSide.Back);
        }

        return card;
    }

    public IQueryable<BaseballCard> GetAll()
    {
        var dbContext = _contextFactory.CreateDbContext();

        return dbContext.BaseballCards
            .AsNoTracking()
            .Include(b => b.Brand)
            .OrderBy(b => b.PlayerName)
            .Select(b => BaseballCard.FromDto(b));
    }

    public async Task<int> Add(BaseballCard card)
    {
        var dbContext = await _contextFactory.CreateDbContextAsync();

        var brand = dbContext.Brands.FirstOrDefault(b => b.BrandId == card.BrandId);

        if (brand is null)
        {
            throw new ObjectNotFoundException("Unable to find brand");
        }
        
        var newCard = new BaseballCardDto
        {
            BrandId = card.BrandId,
            Brand = brand,
            UserAccountId = card.UserAccountId,
            Year = card.Year,
            CardNumber = card.CardNumber,
            PlayerName = card.PlayerName,
            PlayerPosition = card.PlayerPosition,
            Team = card.Team,
            Flags = card.Flags,
            Quantity = card.Quantity,
        };
        
        dbContext.BaseballCards.Add(newCard);

        await dbContext.SaveChangesAsync();

        return newCard.BaseballCardId;
    }

    public async Task Update(BaseballCard card)
    {
        var dbContext = await _contextFactory.CreateDbContextAsync();

        var baseballCard = dbContext.BaseballCards.FirstOrDefault(b => b.BaseballCardId == card.BaseballCardId);

        if (baseballCard is null)
        {
            throw new ObjectNotFoundException("Unable to find the specified brand");
        }
        
        baseballCard.UserAccountId = card.UserAccountId;
        baseballCard.Year = card.Year;
        baseballCard.CardNumber = card.CardNumber;
        baseballCard.PlayerName = card.PlayerName;
        baseballCard.PlayerPosition = card.PlayerPosition;
        baseballCard.Team = card.Team;
        baseballCard.Flags = card.Flags;
        baseballCard.Quantity = card.Quantity;

        dbContext.BaseballCards.Update(baseballCard);

        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(int baseballCardId)
    {
        var dbContext = await _contextFactory.CreateDbContextAsync();

        _fileService.DeleteImage(Constants.CardType.Baseball, baseballCardId);
        _fileService.DeleteImage(Constants.CardType.Baseball, baseballCardId, Constants.CardSide.Back);
        
        await dbContext.BaseballCards.Where(b => b.BaseballCardId == baseballCardId).ExecuteDeleteAsync();

        await dbContext.SaveChangesAsync();
    }

    public async Task AddImageToBaseballCard(int id, string filename, Constants.CardSide side, Stream stream)
    {
        var dbContext = await _contextFactory.CreateDbContextAsync();
        
        var baseballCard = dbContext.BaseballCards.FirstOrDefault(b => b.BaseballCardId == id);

        if (baseballCard is null)
        {
            throw new ObjectNotFoundException("Unable to find the specified brand");
        }

        if (side == Constants.CardSide.Front && baseballCard.FrontImageUrl != string.Empty)
        {
            _fileService.DeleteImage(Constants.CardType.Baseball, id);
        }
        
        if (side == Constants.CardSide.Back && baseballCard.BackImageUrl != string.Empty)
        {
            _fileService.DeleteImage(Constants.CardType.Baseball, id, Constants.CardSide.Back);
        }

        var savedFile = await _fileService.SaveImage(stream, Constants.CardType.Baseball, id, filename, side);

        baseballCard.FrontImageUrl = savedFile;

        dbContext.Update(baseballCard);

        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveImageFromBaseballCard(int id, Constants.CardSide side)
    {
        var dbContext = await _contextFactory.CreateDbContextAsync();
        
        var baseballCard = dbContext.BaseballCards.FirstOrDefault(b => b.BaseballCardId == id);

        if (baseballCard is null)
        {
            throw new ObjectNotFoundException("Unable to find the specified brand");
        }

        _fileService.DeleteImage(Constants.CardType.Baseball, id, side);

        baseballCard.FrontImageUrl = "";

        dbContext.Update(baseballCard);

        await dbContext.SaveChangesAsync();
    }

    public IEnumerable<BaseballCard> GetAllWithImageData()
    {
        var cards = GetAll();

        List<BaseballCard> baseballCards = new();

        foreach (var card in cards.ToList())
        {
            if (card.FrontImageUrl != string.Empty)
            {
                card.FrontImageData = _fileService.GetImage(Constants.CardType.Baseball, card.BaseballCardId);
            }

            baseballCards.Add(card);
        }

        return baseballCards;
    }

    public (IEnumerable<BaseballCard> Cards, int TotalCards) GetAllPaginatedWithImageData(BaseballCardFilters filters, int currentPage, int cardsPerPage)
    {
        var filterYear = filters.Year ?? 0;
        
        var cards = GetAll()
            .ToList()
            .Where(c => c.Team == filters.Team || filters.Team == string.Empty)
            .Where(c => c.BrandId == filters.BrandId || filters.BrandId == 0)
            .Where(c => c.Year == filterYear || filterYear == 0)
            .ToList();

        var cardsForPage = cards
            .Skip((currentPage - 1) * cardsPerPage)
            .Take(cardsPerPage)
            .ToList();
        
        List<BaseballCard> baseballCards = new();
        
        foreach (var card in cardsForPage)
        {
            if (card.FrontImageUrl != string.Empty)
            {
                card.FrontImageData = _fileService.GetImage(Constants.CardType.Baseball, card.BaseballCardId);
            }

            baseballCards.Add(card);
        }

        return (baseballCards, cards.Count);
    }
}