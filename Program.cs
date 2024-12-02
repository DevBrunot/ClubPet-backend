using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao container
builder.Services.AddControllers(); // Adiciona os controladores
builder.Services.AddSwaggerGen(); // Swagger (opcional)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Adiciona o DbContext

// Adicione seus próprios serviços aqui
builder.Services.AddScoped<IMyService, MyService>();

var app = builder.Build();

// Configuração do pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers(); // Mapeia automaticamente as rotas para os controladores

app.Run();
