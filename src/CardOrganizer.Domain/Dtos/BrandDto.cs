using System.Collections.Generic;
using System.Linq;

namespace CardOrganizer.Domain.Dtos;

public class BrandDto
{
    public int BrandId { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public int CardTypeId { get; set; }

    public bool IsActive { get; set; } = true;
    
    public IEnumerable<BaseballCardDto> BaseballCards { get; set; } = Enumerable.Empty<BaseballCardDto>();
}