using System.IO;
using CardOrganizer.Application.Services;
using CardOrganizer.Domain;
using Microsoft.Extensions.Hosting;

namespace CardOrganizer.Infrastructure.Services;

public class FileService : IFileService
{
    private readonly IImageService _imageService;
    private readonly IHostEnvironment _hostEnvironment;

    public FileService(IImageService imageService, IHostEnvironment hostEnvironment)
    {
        _imageService = imageService;
        _hostEnvironment = hostEnvironment;
    }
    
    public async Task<string> SaveImage(Stream stream, Constants.CardType cardType, int id, string imageName, Constants.CardSide side = Constants.CardSide.Front)
    {
        var file = new FileInfo(imageName);

        var imageType = file.Extension.ToLower() switch
        {
            ".jpg" => Constants.ImageType.Jpeg,
            ".jpeg" => Constants.ImageType.Jpeg,
            ".png" => Constants.ImageType.Png,
            ".gif" => Constants.ImageType.Gif,
            _ => throw new Exception("Unknown image type")
        };

        var directory = GetDirectory(cardType);
        
        if (!Directory.Exists($"uploads/{directory}"))
        {
            Directory.CreateDirectory($"uploads/{directory}");
        }

        var filename = Path.Combine(_hostEnvironment.ContentRootPath, $"uploads/{directory}/{id}_{side.ToString().ToLower()}.jpg");

        using var memoryStream = new MemoryStream();
        
        await stream.CopyToAsync(memoryStream);

        memoryStream.Seek(0, SeekOrigin.Begin);

        await _imageService.SaveImage(memoryStream, imageType, filename);

        return filename;
    }

    public string GetImage(Constants.CardType cardType, int id, Constants.CardSide side = Constants.CardSide.Front)
    {
        var directory = GetDirectory(cardType);
        var imageFilename = Path.Combine(_hostEnvironment.ContentRootPath, $"uploads/{directory}/{id}_{side.ToString().ToLower()}.jpg");

        if (!File.Exists(imageFilename))
        {
            return string.Empty;
        }

        return _imageService.ConvertToBase64(imageFilename);
    }

    public void DeleteImage(Constants.CardType cardType, int id, Constants.CardSide side = Constants.CardSide.Front)
    {
        var directory = GetDirectory(cardType);
        
        var imageFilename = Path.Combine(_hostEnvironment.ContentRootPath, $"uploads/{directory}/{id}_{side.ToString().ToLower()}.jpg");

        if (File.Exists(imageFilename))
        {
            File.Delete(imageFilename);
        }
    }

    private string GetDirectory(Constants.CardType cardType) => cardType switch
    {
        Constants.CardType.Baseball => "baseball",
        Constants.CardType.Football => "football",
        _ => "other"
    };
}