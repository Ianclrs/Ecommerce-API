using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;

namespace Domain.Interfaces;

public interface ICarrinhoRepository
{
    void Remover(int id);
    List<Carrinho> Listar();
    decimal CalcularTotal(int IdCarrinho);

}
