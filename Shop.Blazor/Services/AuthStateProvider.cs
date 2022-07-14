using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Shop.Common.Helpers;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Shop.Blazor.Services
{
    public class AuthStateProvider: AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;

        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await localStorageService.GetItemAsync<string>("JWT Token");
            if (token == null)
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(
                new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJWT(token))));
            
        } 
    }
}
