using Shop.Blazor.Admin.Services.Contracts;
using Shop.Common.Models;

namespace Shop.Blazor.Admin.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task DeleteProduct(string id)
        {
            await httpClient.DeleteAsync($"/catalog/{id}");
        }

        public async Task EditProduct(Product product)
        {
            await httpClient.PutAsJsonAsync($"/catalog/{product.Id}", product);
        }

        public Task<Product> GetProduct(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
