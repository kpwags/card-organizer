using System.IO;
using CardOrganizer.Domain;

namespace CardOrganizer.Application.Services;

public interface IFileService
{
    Task<string> SaveImage(Stream stream, Constants.CardType cardType, int id, string imageName, Constants.CardSide side = Constants.CardSide.Front);

    void DeleteImage(Constants.CardType cardType, int id, Constants.CardSide side = Constants.CardSide.Front);

    string GetImage(Constants.CardType cardType, int id, Constants.CardSide side = Constants.CardSide.Front);
}