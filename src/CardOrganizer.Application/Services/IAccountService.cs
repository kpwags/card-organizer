namespace CardOrganizer.Application.Services;

public interface IAccountService
{
    Task<UserAccount> RegisterUser(UserAccount user, string password);

    Task<UserAccount> LoginUser(string email, string password);
}