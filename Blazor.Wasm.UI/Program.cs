using Blazor.Wasm.UI;
using Blazor.Wasm.UI.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMatBlazor();
builder.Services.AddHttpClient("Blazor.WASM.API", options => options.BaseAddress =new Uri("https://localhost:7253/"));

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Blazor.WASM.API"));
builder.Services.AddMatToaster(config =>
{
    config.Position = MatToastPosition.BottomRight;
    config.PreventDuplicates = true;
    config.NewestOnTop = true;
    config.ShowCloseButton = true;
    config.MaximumOpacity = 95;
    config.VisibleStateDuration = 3000;
});

builder.Services.AddCascadingValue(x => new ThemeInfo("btn-primary", "btn-info", "btn-danger"));

builder.Services.AddCascadingValue("Counter",x => new ThemeInfo("btn-primary", "btn-info", "btn-danger"));



await builder.Build().RunAsync();
