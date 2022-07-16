using Shop.Common.ViewModels;

namespace Shop.Blazor.Services.Contracts
{
    public interface IAccountService
    {
        Task<bool> Login(LoginViewModel login);
        Task Logout();
    }
}
