using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades;

public class Pagamento
{
    public int Id { get; set; }
    public int IdPedido { get; set; }

    public decimal TotalCompra { get; private set; }
    public decimal ValorFrete { get; private set; }
    public decimal TotalPago { get; private set; }

    public bool FoiPago { get; private set; }
    public DateTime DataPagamento { get; private set; }

    public Pagamento(int pedidoId, decimal totalCompra, decimal valorFrete)
    {
        IdPedido = pedidoId;
        TotalCompra = totalCompra;
        ValorFrete = valorFrete;

        TotalPago = totalCompra + valorFrete;
        FoiPago = false;

    }


    public void ConfirmarPagamento()
    {
        FoiPago = true;
        DataPagamento = DateTime.Now;
    }
}

