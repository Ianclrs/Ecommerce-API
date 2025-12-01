using Domain.Entidades;
namespace Application.DTOs;

public class PagamentoDTO
{
    public int PedidoId { get; set; }
    public int ClienteId { get; set; }        
    public decimal TotalCompra { get; set; }  
    public decimal ValorFrete { get; set; }   
   public decimal TotalAPagar { get; set; }
    public bool FoiPago { get; set; }
    public DateTime? DataPagamento { get; set; }
}


