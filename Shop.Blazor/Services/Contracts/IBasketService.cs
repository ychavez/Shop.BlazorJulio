using Shop.Blazor.Models;

namespace Shop.Blazor.Services.Contracts
{
    public interface IBasketService
    {
        Task<Basket> GetBasketAsync(string userName);
        Task UpdateAsync(Basket basket);
        Task Checkout(Checkout checkout);
    }
}
