using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazm.Bluetooth;
using ChristianSchulz.CarreraDigital;
using ChristianSchulz.CarreraDigital.Blazm.Bluetooth;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ChristianSchulz.CarreraDigitalApp.Client;

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