using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Shop.Blazor.Pages
{
    public partial class RedirectToLogin
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> AuthState { get; set; }

        public bool NotAuthorized { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthState;

            if (authState?.User?.Identity is null 
                || !authState.User.Identity.IsAuthenticated)
            {
                var returnUrl = NavigationManager.
                    ToBaseRelativePath(NavigationManager.Uri);
                if (string.IsNullOrEmpty(returnUrl))
                    NavigationManager.NavigateTo("Login");
                else
                    NavigationManager.NavigateTo($"Login?returnUrl={returnUrl}");
            }
            NotAuthorized = true;
        }

    }
  
}
