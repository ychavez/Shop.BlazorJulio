using Shop.Blazor.Models;
using Shop.Blazor.Services.Contracts;
using System.Net.Http.Json;

namespace Shop.Blazor.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient
                ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<Product> GetAsync(string productID)
        => await httpClient.GetFromJsonAsync<Product>($"/catalog/{productID}")
                ?? throw new Exception($"El productid {productID} no existe");

        public async Task<List<Product>> GetProductsAsync()
        {
            return await httpClient.GetFromJsonAsync<List<Product>>("/catalog")
        ?? throw new Exception($"Error al traerse el catalogo de productos");
        }
    }
}
