using CardOrganizer.Domain;

namespace CardOrganizer.Application.Models;

public class BaseballCardFilters
{
    public int BrandId { get; set; }

    public string Team { get; set; } = string.Empty;
    
    public int? Year { get; set; }

    public bool HasFiltersApplied => BrandId != 0 || Team != string.Empty || Year is not null or > 0;
}