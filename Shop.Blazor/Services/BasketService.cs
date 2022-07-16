using Shop.Blazor.Models;
using Shop.Blazor.Services.Contracts;
using Shop.Common.Models;
using System.Net.Http.Json;

namespace Shop.Blazor.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient httpClient;
        private readonly IProductService productService;

        public BasketService(HttpClient httpClient, IProductService productService)
        {
            this.httpClient = httpClient;
            this.productService = productService;
        }
        public async Task Checkout(Checkout checkout)
        {
            await httpClient.PostAsJsonAsync("/Basket/Checkout", checkout);
        }

        public async Task<Basket> GetBasketAsync(string userName)
        {
            var basket = await httpClient.GetFromJsonAsync<Basket>($"/basket/{userName}")
                ?? throw new Exception($"Error al intentar traer el carrito de {userName}");

            foreach (var item in basket.Items)
            {
                Product product = await productService.GetAsync(item.ProductId);
                item.ImageURL = product.ImageURL;
                item.Price = product.Price;
            }
            
            return basket;
        }

        public async Task UpdateAsync(Basket basket)
        {
            await httpClient.PostAsJsonAsync("/Basket", basket);
        }
    }
}
