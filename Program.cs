var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(); // Registra os controladores da API

var app = builder.Build();

// Configuração do pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Exibe detalhes do erro no modo de desenvolvimento
}

app.UseRouting();

app.MapControllers(); // Mapeia automaticamente as rotas dos controladores

app.Run();
