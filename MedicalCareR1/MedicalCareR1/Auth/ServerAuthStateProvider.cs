using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MedicalCareR1.Auth;

public class ServerAuthStateProvider(IHttpContextAccessor _httpContextAccessor) : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = _httpContextAccessor.HttpContext?.User
                   ?? new ClaimsPrincipal(new ClaimsIdentity());

        return Task.FromResult(new AuthenticationState(user));
    }
}
