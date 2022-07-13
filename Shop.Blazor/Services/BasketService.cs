using Shop.Blazor.Models;
using Shop.Blazor.Services.Contracts;
using System.Net.Http.Json;

namespace Shop.Blazor.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient httpClient;

        public BasketService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public Task Checkout()
        {
            throw new NotImplementedException();
        }

        public async Task<Basket> GetBasketAsync(string userName)
        {
            return await httpClient.GetFromJsonAsync<Basket>($"/basket/{userName}")
                ?? throw new Exception($"Error al intentar traer el carrito de {userName}");
        }

        public async Task UpdateAsync(Basket basket)
        {
            await httpClient.PostAsJsonAsync("/Basket", basket);
        }
    }
}
