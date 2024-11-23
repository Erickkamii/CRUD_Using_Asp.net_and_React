using back.Modelos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar o ProdutoContexto ao contêiner de serviços
builder.Services.AddDbContext<ProdutoContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar suporte a controladores
builder.Services.AddControllers(); // Necessário para usar controladores

// Adicionar serviços relacionados à API e Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Permite requisições do React
              .AllowAnyMethod() // Permite todos os métodos (GET, POST, PUT, DELETE)
              .AllowAnyHeader(); // Permite qualquer cabeçalho
    });
});

var app = builder.Build();

// Configurar o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Produtos v1");
        c.RoutePrefix = string.Empty; // O Swagger ficará acessível na raiz (http://localhost:<porta>/)
    });
}

// Usar o CORS configurado
app.UseCors("ReactPolicy");

app.UseHttpsRedirection();
app.UseAuthorization(); // Necessário se você usar autenticação
app.MapControllers(); // Mapeia os controladores automaticamente

app.Run();
