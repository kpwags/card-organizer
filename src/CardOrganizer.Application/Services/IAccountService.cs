using CardOrgamizer.Domain.Models;
using System.Threading.Tasks;

namespace CardOrganizer.Application.Services;

public interface IAccountService
{
    Task<UserAccount> RegisterUser(UserAccount user, string password);

    Task<UserAccount> LoginUser(string email, string password);
}