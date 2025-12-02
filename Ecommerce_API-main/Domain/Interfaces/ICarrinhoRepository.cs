using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;

namespace Domain.Interfaces;

public interface ICarrinhoRepository
{
    void AdicionarCarrinho(Carrinho carrinho);
    void Remover(int id);
    List<Carrinho> Listar();
    void AdicionarItem(int idCarrinho, ItemCarrinho item);
    void RemoverItem(int idCarrinho, int idItem);
    void SubtrairQuantidadeItem(int idCarrinho, int idItem, int decrescimo);
    List<ItemCarrinho> ListarItensCarrinho(int idCarrinho);
}
