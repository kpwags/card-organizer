using System.IO;
using System.Collections.Generic;
using CardOrganizer.Application.Models;
using CardOrganizer.Domain;

namespace CardOrganizer.Application.Repositories;

public interface IBaseballCardRepository : IRepository<BaseballCard>
{
    Task AddImageToBaseballCard(int id, string filename, Constants.CardSide side, Stream stream);

    Task RemoveImageFromBaseballCard(int id, Constants.CardSide side);

    IEnumerable<BaseballCard> GetAllWithImageData();

    (IEnumerable<BaseballCard> Cards, int TotalCards) GetAllPaginatedWithImageData(BaseballCardFilters filters, int currentPage, int cardsPerPage);
}