using Ecommerce_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Registra controllers e serviços
builder.Services.AddControllers();
builder.Services.AddScoped<CarrinhoService>(); // Ajuste se usar interface

// Swagger para testar via navegador
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();