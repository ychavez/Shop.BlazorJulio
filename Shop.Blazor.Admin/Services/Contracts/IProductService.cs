using Shop.Common.Models;

namespace Shop.Blazor.Admin.Services.Contracts
{
    public interface IProductService
    {
        Task DeleteProduct(string id);
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task EditProduct(Product product);
        
    }
}
