using Domain.Entidades;

namespace Domain.Interfaces;

public interface IProdutoRepository
{
    void Incluir(Produto produto);
    List<Produto> Listar();

    void Remover(int id);

    void AtualizarEstoque(int produtoId, int quantidade);
}
