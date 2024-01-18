using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using crud;
using crud.DAL;
using crud.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register ProductRepository
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//Register DB
builder.Services.AddScoped<IProductService, ProductService>();


// Register ProductContext
builder.Services.AddDbContext<ProductContext>();

// Register HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();