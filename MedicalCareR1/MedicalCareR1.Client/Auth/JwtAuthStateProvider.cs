using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MedicalCareR1.Client.Auth;

public class JwtAuthStateProvider : AuthenticationStateProvider
{
    private static readonly AuthenticationState Anonimo =
        new(new ClaimsPrincipal(new ClaimsIdentity()));

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Por ahora retorna anónimo — aquí luego leerás el token JWT
        return Task.FromResult(Anonimo);
    }
}