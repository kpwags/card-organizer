using CardOrganizer.Application.Services;
using Microsoft.AspNetCore.Identity;

namespace CardOrganizer.Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<UserAccountDto> _userManager;
    private readonly SignInManager<UserAccountDto> _signInManager;
    
    public AccountService(
        UserManager<UserAccountDto> userManager,
        SignInManager<UserAccountDto> signInManager
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task<UserAccount> RegisterUser(UserAccount userAccount, string password)
    {
        var user = await _userManager.FindByEmailAsync(userAccount.Email);

        if (user is not null)
        {
            throw new Exception("User already exists");
        }

        var newUser = new UserAccountDto
        {
            Name = userAccount.Name,
            Email = userAccount.Email,
            UserName = userAccount.Email,
        };

        var result = await _userManager.CreateAsync(newUser, password);

        user = await _userManager.FindByEmailAsync(userAccount.Email);
        
        if (!result.Succeeded || user is null)
        {
            throw new Exception("Unable to create user account");
        }

        return UserAccount.FromDto(user);
    }

    public async Task<UserAccount> LoginUser(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            throw new Exception("Invalid username or password.");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

        if (result.Succeeded)
        {
            return UserAccount.FromDto(user);
        }
        
        throw new Exception("Invalid username or password.");
    }
}