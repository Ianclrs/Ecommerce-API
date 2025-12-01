using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IPagamentoRepository 
{
    void Salvar(Pagamento pagamento);
    Pagamento ObterPorPedidoId(int pedidoId);
}
/*public class PagamentoViaCartao : IPagamento
{
    private int _parcelas;
    public DateTime Vencimento { get; set; } = DateTime.Now;
    public decimal Valor { get; set; }
    public List<DateTime> ListaDeVencimentos { get; private set; } = new List<DateTime>(); // Armazena as datas de vencimento das parcelas
    public int Parcelas
    {
        get { return _parcelas; }
        set
        {
            _parcelas = value;
            CalcularDatasDasParcelas();
        }
    }
    private void CalcularDatasDasParcelas() // Calcula as datas de vencimento das parcelas
    {
        ListaDeVencimentos.Clear();

        for (int i = 1; i <= _parcelas; i++)
        {
            DateTime dataParcela = Vencimento.AddMonths(i);
            ListaDeVencimentos.Add(dataParcela);
        }
    }
}
public class PagamentoViaPix : IPagamento
{
    public DateTime Vencimento { get; set; } = DateTime.Now.AddMinutes(30);
    public decimal Valor { get; set; }

}
public class PagamentoViaBoleto : IPagamento
{
    public DateTime Vencimento { get; set; } = DateTime.Now.AddMonths(1);
    public decimal Valor { get; set; }

´}*/
