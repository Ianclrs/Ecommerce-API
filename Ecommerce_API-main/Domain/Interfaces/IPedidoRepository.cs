using Domain.Entidades;

namespace Domain.Interfaces;

public interface IPedidoRepository
{
    void Incluir(Pedido pedido);
    List<Pedido> Listar();
    void Remover(int id);
}
