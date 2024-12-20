using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Password_Generator_V2.Logic;

namespace Password_Generator_V2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "/Password-Generator-V2/") });
            builder.Services.AddScoped(typeof(StorageService));
            builder.Services.AddScoped(typeof(AppStateService));

            await builder.Build().RunAsync();
        }
    }
}
