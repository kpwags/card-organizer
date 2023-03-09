using System.IO;

namespace CardOrganizer.Application.Repositories;

public interface IBaseballCardRepository : IRepository<BaseballCard>
{
    Task AddImageToBaseballCard(int id, string filename, Stream stream);

    Task RemoveImageFromBaseballCard(int id);
}