namespace CardOrganizer.Domain.Models;

public class BaseballCard
{
    public int BaseballCardId { get; set; }
    
    public int BrandId { get; set; }
    
    public int UserAccountId { get; set; }
    
    public int Year { get; set; }
    
    public int CardNumber { get; set; }

    public string PlayerName { get; set; } = string.Empty;
    
    public string PlayerPosition { get; set; } = string.Empty;

    public string Team { get; set; } = string.Empty;

    public string Flags { get; set; } = string.Empty;

    public string FrontImageUrl { get; set; } = string.Empty;

    public string FrontImageData { get; set; } = string.Empty;

    public string BackImageUrl { get; set; } = string.Empty;

    public string BackImageData { get; set; } = string.Empty;
    
    public int Quantity { get; set; }

    public Brand Brand { get; set; } = new Brand();

    public UserAccount UserAccount { get; set; } = new UserAccount();

    public static BaseballCard FromDto(BaseballCardDto dto) => new BaseballCard
    {
        BaseballCardId = dto.BaseballCardId,
        BrandId = dto.BrandId,
        UserAccountId = dto.UserAccountId,
        Year = dto.Year,
        CardNumber = dto.CardNumber,
        PlayerName = dto.PlayerName,
        PlayerPosition = dto.PlayerPosition,
        Team = dto.Team,
        Flags = dto.Flags,
        FrontImageUrl = dto.FrontImageUrl,
        BackImageUrl = dto.BackImageUrl,
        Quantity = dto.Quantity,
        Brand = Brand.FromDto(dto.Brand),
        UserAccount = UserAccount.FromDto(dto.UserAccount)
    };
}