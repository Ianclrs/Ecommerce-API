using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades;

public class Pagamento
{

    public int IdPagamento { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataPagamento { get; set; }
}

