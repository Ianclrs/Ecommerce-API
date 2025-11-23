using Domain.Entidades;

namespace Domain.Interfaces;

public interface IFrete
{// Define o método para calcular o frete com base no cliente
    decimal CalcularFrete(Cliente cliente);
}
public class RJ : IFrete
{// Implementa o cálculo de frete específico para o Rio de Janeiro
    public decimal CalcularFrete(Cliente cliente)
    {
       
        Console.WriteLine("Frete grátis para o Rio de Janeiro!");
        return 0m;
    }
}
public class SP : IFrete
{// Implementa o cálculo de frete específico para São Paulo
    public decimal CalcularFrete(Cliente cliente)
    {
        Console.WriteLine("Frete fixo para São Paulo.");
        return 20m;
    }
}
public class MG : IFrete
{// Implementa o cálculo de frete específico para Minas Gerais
    public decimal CalcularFrete(Cliente cliente)
    {
        Console.WriteLine("Frete fixo para Minas Gerais.");
        return 15m;
    }
}