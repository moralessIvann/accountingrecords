using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using WebApp.Client;
using WebApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5056") });

var newCulture = new System.Globalization.CultureInfo("en-US");
builder.Services.AddSingleton(newCulture);

builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IActivoFijoService, ActivoFijoService>();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
