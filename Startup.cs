using crud.DAL;

using Microsoft.EntityFrameworkCore;

namespace crud
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Use a connection string específica do MariaDB/MySQL no seu appsettings.json
            string? mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ProductContext>(options =>
                options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect("10.4"))); // UseMySql em vez de UseSqlServer

            // Adicione outros serviços conforme necessário
            // services.AddScoped<IProductRepository, ProductRepository>();
            // services.AddScoped<IProductService, ProductService>();
        }

        
    }
}