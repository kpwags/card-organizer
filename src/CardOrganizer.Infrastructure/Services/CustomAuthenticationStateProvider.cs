using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CardOrganizer.Infrastructure.Services;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly UserManager<UserAccountDto> _userManager;
    private readonly ISessionStorageService _sessionStorageService;
    
    public CustomAuthenticationStateProvider(UserManager<UserAccountDto> userManager, ISessionStorageService sessionStorageService)
    {
        _userManager = userManager;
        _sessionStorageService = sessionStorageService;
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();;
        
        var userId = await _sessionStorageService.GetItemAsync<int>("userId");
        
        if (userId > 0)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is not null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim("UserAccountId", user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email ?? ""),
                    new Claim(ClaimTypes.Name, user.Name)
                }, "CardOrgAuth");
            }
            else
            {
                // can't find the user, kill the session
                await _sessionStorageService.RemoveItemAsync("userId");
            }
        }

        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
    }

    public async Task StartUserSession(UserAccount user)
    {
        await _sessionStorageService.SetItemAsync("userId", user.UserAccountId);
        
        var identity = new ClaimsIdentity(new[]
        {
            new Claim("UserAccountId", user.UserAccountId.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name)
        });
        
        var userAccount = new ClaimsPrincipal(identity);
        
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(userAccount)));
    }

    public async Task EndUserSession()
    {
        await _sessionStorageService.RemoveItemAsync("userId");

        var identity = new ClaimsIdentity();
        
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
    }
}