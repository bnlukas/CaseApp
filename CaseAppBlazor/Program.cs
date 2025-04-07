using Blazored.LocalStorage;
using CaseApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CaseAppBlazor;
using CaseAppBlazor.Service;
using CaseAppBlazor.Service.Login;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ILoginService, LoginServiceClientSide>(); // Eller LoginServiceServerSide
builder.Services.AddSingleton<IStoreService, StoreService>();
await builder.Build().RunAsync();