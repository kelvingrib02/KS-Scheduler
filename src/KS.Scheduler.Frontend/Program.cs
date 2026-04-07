using Blazored.LocalStorage;
using KS.Scheduler.Frontend;
using KS.Scheduler.Frontend.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5185/")
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();