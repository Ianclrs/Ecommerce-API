using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    internal interface IPagamento
    {
        DateTime Vencimento { get; set; }
        decimal Valor { get; set; }
    }
    public class PagamentoViaCartao : IPagamento
    {
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; }
    }
    public class PagamentoViaPix : IPagamento
    {
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; }
    }
    public class PagamentoViaBoleto : IPagamento
    {
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; }

    }
}
