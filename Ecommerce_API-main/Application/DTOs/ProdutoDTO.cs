using Domain.Entidades;

namespace Application.DTOs;
public class ProdutoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public Produto Mapear()
    {
        return new Produto
        {
            Id = this.Id,
            Nome = this.Nome,
            Quantidade = this.Quantidade
        };
    }
}
