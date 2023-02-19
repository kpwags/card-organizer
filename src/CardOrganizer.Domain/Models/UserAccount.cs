namespace CardOrganizer.Domain.Models;

public class UserAccount
{
    public int UserAccountId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public static UserAccount FromDto(UserAccountDto dto) => new UserAccount
    {
        UserAccountId = dto.Id,
        Name = dto.Name,
        Email = dto.Email ?? "",
    };
}