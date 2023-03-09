using System.Collections.Generic;

namespace CardOrganizer.Domain.Dtos;

public class BrandDto
{
    public int BrandId { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public int CardTypeId { get; set; }

    public bool IsActive { get; set; } = true;

    public List<BaseballCardDto> BaseballCards { get; set; } = new List<BaseballCardDto>();
}