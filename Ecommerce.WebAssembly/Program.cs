using Ecommerce.WebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

//Inyectando dependencias para el carrito
using Blazored.LocalStorage;
//Para mensajes
using Blazored.Toast;
//servicio carrito
using Ecommerce.WebAssembly.Servicios.Implementacion;
using Ecommerce.WebAssembly.Servicios.Contrato;
//servicio que personaliza alertas
using CurrieTechnologies.Razor.SweetAlert2;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5201/api/") });

//Inyectando dependencias para el carrito
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
//inyectando servicios para luego usarlos en webassembly
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<ICarritoServicio, CarritoServicio>();
builder.Services.AddScoped<IVentaServicio, VentaServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();

//sweetalert
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
