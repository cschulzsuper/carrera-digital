using Blazm.Bluetooth;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Super.Carrera.Digital;
using Super.Carrera.Digital.Blazm.Bluetooth;
using Super.Carrera.Digital.Blazor.Client;

namespace Company.WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazmBluetooth();
            builder.Services.AddCarreraControlUnit<BlazmBluetoothControlUnitAdapter>();

            await builder.Build().RunAsync();
        }
    }
}