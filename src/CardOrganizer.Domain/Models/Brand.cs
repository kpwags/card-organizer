using CardOrganizer.Domain.Dtos;

namespace CardOrganizer.Domain.Models;

public class Brand
{
    public int BrandId { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public Constants.CardType CardType { get; set; }

    public bool IsActive { get; set; } = true;

    public static Brand FromDto(BrandDto dto) => new Brand
    {
        BrandId = dto.BrandId,
        Name = dto.Name,
        CardType = (Constants.CardType)dto.CardTypeId,
        IsActive = dto.IsActive,
    };
}