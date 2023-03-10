using System.IO;
using CardOrganizer.Domain;

namespace CardOrganizer.Application.Services;

public interface IImageService
{
    Task<byte[]> ResizeImage(Stream stream, Constants.ImageType type, int? desiredWidth = null, int? desiredHeight = null);

    Task SaveImage(byte[] img, Constants.ImageType type, string path);

    Task SaveImage(Stream stream, Constants.ImageType type, string path);

    string ConvertToBase64(byte[] img);

    string ConvertToBase64(string filepath);
}