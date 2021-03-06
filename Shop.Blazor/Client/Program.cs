using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shop.Blazor;
using Shop.Blazor.Services;
using Shop.Blazor.Services.Contracts;
using Sotsera.Blazor.Toaster.Core.Models;

namespace Company.WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            HttpClient http = new()
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            };

            builder.Services.AddScoped(sp => http);

            using var response = await http.GetAsync("appsettings.json");
            using var stream = await response.Content.ReadAsStreamAsync();

            builder.Configuration.AddJsonStream(stream);


            builder.Services.AddScoped(sp =>
            new HttpClient { BaseAddress = new Uri(builder.Configuration["BaseAddress"] ?? "/") });

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IBasketService, BasketService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddToaster(config =>
            {
                config.PositionClass = Defaults.Classes.Position.TopRight;

            });

            await builder.Build().RunAsync();
        }
    }
}