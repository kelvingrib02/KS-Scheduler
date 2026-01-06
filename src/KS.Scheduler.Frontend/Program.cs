using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using KS.Scheduler.Frontend;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var urlDaApi = "http://localhost:5185";

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(urlDaApi) });

await builder.Build().RunAsync();