using System.Text.Json;
using CardOrganizer.Application.Repositories;
using CardOrganizer.Domain.Exceptions;
using CardOrganizer.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CardOrganizer.Infrastructure.Repositories;

public class BrandRepository : IBrandRespository
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
    
    public BrandRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public Brand GetById(int brandId)
    {
        var dbContext = _contextFactory.CreateDbContext();

        var brand = dbContext.Brands.FirstOrDefault(b => b.BrandId == brandId);

        if (brand is null)
        {
            throw new ObjectNotFoundException("Unable to find the specified brand");
        }

        return Brand.FromDto(brand);
    }
    
    public IQueryable<Brand> GetAll()
    {
        var dbContext = _contextFactory.CreateDbContext();

        return dbContext.Brands
            .OrderBy(b => b.Name)
            .Select(b => Brand.FromDto(b));
    }

    public async Task<int> Add(Brand brand)
    {
        var dbContext = await _contextFactory.CreateDbContextAsync();

        var newBrand = new BrandDto
        {
            Name = brand.Name,
            IsActive = brand.IsActive,
            CardTypeId = (int)brand.CardType,
        };
        
        dbContext.Brands.Add(newBrand);

        await dbContext.SaveChangesAsync();

        return newBrand.BrandId;
    }

    public async Task Update(Brand brand)
    {
        var dbContext = await _contextFactory.CreateDbContextAsync();

        var cardBrand = dbContext.Brands.FirstOrDefault(b => b.BrandId == brand.BrandId);

        if (cardBrand is null)
        {
            throw new ObjectNotFoundException("Unable to find the specified brand");
        }

        cardBrand.Name = brand.Name;
        cardBrand.IsActive = brand.IsActive;
        cardBrand.CardTypeId = (int)brand.CardType;

        dbContext.Brands.Update(cardBrand);

        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(int brandId)
    {
        var dbContext = await _contextFactory.CreateDbContextAsync();

        await dbContext.Brands.Where(b => b.BrandId == brandId).ExecuteDeleteAsync();

        await dbContext.SaveChangesAsync();
    }
}