using Microsoft.AspNetCore.Identity;

namespace CardOrganizer.Domain.Dtos;

public class UserAccountDto : Microsoft.AspNetCore.Identity.IdentityUser<int>
{
    [PersonalData] public string Name { get; set; } = string.Empty;

    [PersonalData] public IEnumerable<BaseballCardDto> BaseballCards { get; set; } = Enumerable.Empty<BaseballCardDto>();
}