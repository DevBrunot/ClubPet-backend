using Microsoft.EntityFrameworkCore;
using ClubPetAPI.Data;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Server=tcp:clubpet-server.database.windows.net,1433;Initial Catalog=clubpet-db;Persist Security Info=False;User ID=thomaz-leal;Password=Azure@123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
        services.AddScoped<UsuarioRepository>(); 

        services.AddControllers();
    }

    
} 