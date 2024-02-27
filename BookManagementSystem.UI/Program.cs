using BookManagementSystem.UI;
using BookManagementSystem.UI.Services.Base;
using BookManagementSystem.UI.UnitOfWork;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7249"));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

await builder.Build().RunAsync();
