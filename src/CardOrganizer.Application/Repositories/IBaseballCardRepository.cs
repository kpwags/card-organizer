using System.IO;
using CardOrganizer.Domain;

namespace CardOrganizer.Application.Repositories;

public interface IBaseballCardRepository : IRepository<BaseballCard>
{
    Task AddImageToBaseballCard(int id, string filename, Constants.CardSide side, Stream stream);

    Task RemoveImageFromBaseballCard(int id, Constants.CardSide side);
}