namespace CardOrganizer.Domain.Dtos;

public class BaseballCardDto
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

    public string BackImageUrl { get; set; } = string.Empty;
    
    public int Quantity { get; set; }

    public BrandDto Brand { get; set; } = new BrandDto();

    public UserAccountDto UserAccount { get; set; } = new UserAccountDto();
}