using CardOrganizer.Domain.Models;

namespace CardOrganizer.ApiModels;

public class UserAccountApiModel
{
    public int UserAccountId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public static UserAccountApiModel FromDomainModel(UserAccount model) => new UserAccountApiModel
    {
        UserAccountId = model.UserAccountId,
        Name = model.Name,
        Email = model.Email,
    };
}