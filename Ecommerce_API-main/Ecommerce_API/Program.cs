using Domain.Interfaces;
using Ecommerce_API.Services;
using Infrastructure.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Application.DTOs; // <- adicionado para PedidosService

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string caminhoBase = builder.Environment.ContentRootPath;
string caminhoJson = Path.Combine(caminhoBase, "App_Data", "produtos.json");

// Garante que a pasta existe
string? pastaJson = Path.GetDirectoryName(caminhoJson);
if (!string.IsNullOrEmpty(pastaJson))
{
    Directory.CreateDirectory(pastaJson);
}

// adicionar serviços ao contêiner.
builder.Services.AddScoped<ProdutosService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoRepositoryJson, ProdutoRepositoryJson>(provider => new ProdutoRepositoryJson(caminhoJson));
// Serviço de Frete
builder.Services.AddScoped<FreteService>();

// Serviço de ItemCarrinho
builder.Services.AddScoped<ItemCarrinhoService>();

// Serviço do cliente (adicionado)
builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

// ?? Serviço do carrinho (sem repositório)
builder.Services.AddScoped<CarrinhoService>();

// Registros para Pedido
builder.Services.AddScoped<PedidosService>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// em Ecommerce_API/Program.cs, perto de outros registros de repositório
builder.Services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();

WebApplication app = builder.Build();

// configurar o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

