using Microsoft.EntityFrameworkCore;
using ClubPetAPI.Data;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("sua_string_de_conexão_aqui")); 
        services.AddScoped<UsuarioRepository>(); 

        services.AddControllers();
    }

    
} 