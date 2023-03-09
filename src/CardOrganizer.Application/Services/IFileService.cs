using System.IO;
using CardOrganizer.Domain;

namespace CardOrganizer.Application.Services;

public interface IFileService
{
    Task<string> SaveImage(Stream stream, Constants.CardType cardType, int id, string imageName);

    void DeleteImage(Constants.CardType cardType, int id);

    string GetImage(Constants.CardType cardType, int id);
}