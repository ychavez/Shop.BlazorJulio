using Microsoft.AspNetCore.Components;
using Shop.Blazor.Services.Contracts;

namespace Shop.Blazor.Pages
{
    public partial class Logout
    {
        [Inject]
        public IAccountService AccountSevice { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await AccountSevice.Logout();
            NavigationManager.NavigateTo("/");
        }
    }
}
