using CardOrganizer.Application.Services;
using CardOrganizer.Domain;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Gif;
using System.IO;

namespace CardOrganizer.Infrastructure.Services;

public class ImageService : IImageService
{
    public async Task<byte[]> ResizeImage(Stream stream, Constants.ImageType imageType, int? desiredWidth = null, int? desiredHeight = null)
    {
        var decoder = GetDecoder(imageType);

        using var image = await Image.LoadAsync(stream, decoder);

        var aspectRatio = decimal.Parse(image.Width.ToString()) / decimal.Parse(image.Height.ToString());
        int width;
        int height;

        if (desiredWidth is not null)
        {
            width = desiredWidth.Value;
            height = (int)(desiredWidth.Value / aspectRatio);
        }
        else if (desiredHeight is not null)
        {
            height = desiredHeight.Value;
            width = (int)(desiredHeight.Value * aspectRatio);
        }
        else
        {
            throw new Exception("Width or height was not provided");
        }

        image.Mutate(i => i.Resize(width, height));

        using var ms = new MemoryStream();

        await image.SaveAsync(ms, new JpegEncoder());

        return ms.ToArray();
    }

    public async Task SaveImage(byte[] img, Constants.ImageType imageType, string path)
    {
        var decoder = GetDecoder(imageType);

        using var image = Image.Load(img, decoder);

        await image.SaveAsJpegAsync(path);
    }

    public async Task SaveImage(Stream stream, Constants.ImageType imageType, string path)
    {
        var decoder = GetDecoder(imageType);

        using var image = Image.Load(stream, decoder);

        await image.SaveAsJpegAsync(path);
    }

    public string ConvertToBase64(byte[] img)
    {
        using var image = Image.Load(img, new JpegDecoder());

        return image.ToBase64String(JpegFormat.Instance);
    }

    public string ConvertToBase64(string path)
    {
        using var image = Image.Load(path, new JpegDecoder());

        return image.ToBase64String(JpegFormat.Instance);
    }

    private IImageDecoder GetDecoder(Constants.ImageType type) => type switch
    {
        Constants.ImageType.Jpeg => new JpegDecoder(),
        Constants.ImageType.Png => new PngDecoder(),
        Constants.ImageType.Gif => new GifDecoder(),
        _ => throw new Exception("Unknown Image Type")
    };
}