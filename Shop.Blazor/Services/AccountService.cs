﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Shop.Blazor.DTO;
using Shop.Blazor.Services.Contracts;
using Shop.Common.ViewModels;
using System.Net.Http.Json;

namespace Shop.Blazor.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;
        private readonly AuthenticationStateProvider authStateProvider;

        public AccountService(HttpClient httpClient,
            ILocalStorageService localStorageService, AuthenticationStateProvider authStateProvider)
             => (this.httpClient, this.localStorageService, this.authStateProvider) =
             (httpClient, localStorageService, authStateProvider);


        public async Task<bool> Login(LoginViewModel login)
        {
            LoginDTO loginDTO;
            var postResponse = await httpClient.PostAsJsonAsync("Account/Login", login);
            if (postResponse.IsSuccessStatusCode)
            {
                loginDTO = await postResponse.Content.ReadFromJsonAsync<LoginDTO>() ??
                    throw new Exception("Error al tratar de comunicarse con el servicio");

                await localStorageService.SetItemAsync("JWT Token", loginDTO.Token);

                ((AuthStateProvider)authStateProvider).NotifyLoggedIn(loginDTO.Token);

                return true;
            }
            return false;
        }
    }
}