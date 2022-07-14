using Shop.Blazor.Models;

namespace Shop.Blazor.Services.Contracts
{
    public interface IProductService
    {
       public Task<Product> GetAsync(string productID);

        Task<List<Product>> GetProductsAsync();
    }
}
