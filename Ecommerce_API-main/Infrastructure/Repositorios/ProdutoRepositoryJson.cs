using Domain.Entidades;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Repositorios;

public class ProdutoRepositoryJson : IProdutoRepositoryJson
{
    private readonly string _caminhoArquivo;

    // Recebemos o caminho do arquivo via construtor para ser flexível
    public ProdutoRepositoryJson(string caminhoArquivo)
    {
        _caminhoArquivo = caminhoArquivo;
    }

    public List<Produto> ReceberDoArquivo()
    {
        if (!File.Exists(_caminhoArquivo))
            return new List<Produto>();

        string json = File.ReadAllText(_caminhoArquivo);

        // Se o arquivo estiver vazio, retorna lista nova
        if (string.IsNullOrWhiteSpace(json))
            return new List<Produto>();

        return JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
    }

    public void SalvarNoArquivo()
    {
        // Indentacao para deixa o JSON bonitinho (formatado)
        JsonSerializerOptions options = new JsonSerializerOptions();
        string json = JsonSerializer.Serialize(BancoSql.ListaProdutos, options);
        File.WriteAllText(_caminhoArquivo, json);
    }
}
