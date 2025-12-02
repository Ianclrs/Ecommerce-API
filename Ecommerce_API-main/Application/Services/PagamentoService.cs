using Application.DTOs;
using Domain.Entidades;
using Domain.Interfaces;
using Ecommerce_API.Services;
using System.Security.Cryptography.X509Certificates;
using Domain.Helpers;
namespace Ecommerce_API.Services;

    public class PagamentoServicè
{
}

//{
//    private readonly ICarrinhoRepository _carrinhoRepository;
//    private readonly IFrete _freteService;
//    private readonly IPagamentoRepository _pagamentoRepository; // interface fornecida por você
//    private readonly IClienteRepository _clienteRepository;
//    public PagamentoService(
//        ICarrinhoRepository carrinhoRepository,
//        IFrete freteService,
//        IPagamentoRepository pagamentoRepository)
//    {
//        _carrinhoRepository = carrinhoRepository;
//        _freteService = freteService;
//        _pagamentoRepository = pagamentoRepository;
//    }

/// <summary>
/// Realiza o fluxo de pagamento:
/// - busca carrinho pelo cliente
/// - obtém totalCompra do carrinho
/// - calcula frete via IFreteService
/// - cria entidade Pagamento, confirma e salva via IPagamento (repositório)
/// - retorna PagamentoDTO preenchido (resumo)
/// </summary>
//    public PagamentoDTO RealizarPagamento(PagamentoDTO dto)
//    {
//        if (dto == null)
//            throw new ArgumentNullException(nameof(dto));

//        // 1) Obter carrinho do cliente
//        var cliente = _clienteRepository.ObterClientePorId(dto.ClienteId);
//        if (cliente == null)
//            throw new InvalidOperationException("Cliente não encontrado");

//        // 2) Obter total da compra do carrinho (propriedade calculada no Carrinho)
//        var totalCompra = _carrinhoRepository.CalcularTotal();

//        // 3) Calcular frete (corrigido: passar Cliente, não int)
//        var valorFrete = _freteService.CalcularFrete(cliente);

//        // 4) Criar entidade Pagamento
//        var pagamento = new Pagamento(dto.PedidoId, totalCompra, valorFrete);

//        // 5) Confirmar pagamento (no seu caso o pagamento "só diz que deu certo")
//        pagamento.ConfirmarPagamento();

//        // 6) Persistir via repositório
//        _pagamentoRepository.Salvar(pagamento);

//        // 7) Preencher DTO de resposta (resumo)
//        dto.TotalCompra = totalCompra;
//        dto.ValorFrete = valorFrete;
//        dto.TotalAPagar = pagamento.TotalPago;
//        dto.FoiPago = pagamento.FoiPago;
//        dto.DataPagamento = pagamento.DataPagamento;

//        return dto;
//    }

//    // Metodo auxiliar para buscar pagamento por pedido (encapsula IPagamento)
//    public PagamentoDTO ObterResumoPorPedidoId(int pedidoId)
//    {
//        var pagamento = _pagamentoRepository.ObterPorPedidoId(pedidoId);
//        if (pagamento == null) return null;

//        return new PagamentoDTO
//        {
//            PedidoId = pagamento.PedidoId,
//            TotalCompra = pagamento.TotalCompra,
//            ValorFrete = pagamento.ValorFrete,
//            TotalAPagar = pagamento.TotalPago,
//            FoiPago = pagamento.FoiPago,
//            DataPagamento = pagamento.DataPagamento
//        };
//    }
//}

















/*{








    private readonly IPagamento _pagamentoRepository;
    public PagamentoService(IPagamento pagamentoRepository)
    {
        _pagamentoRepository = pagamentoRepository;
    }
    public void ProcessarPagamento(Carrinho carrinho)
    {
        decimal total = carrinho.CalcularTotal();
        _pagamentoRepository.Valor = total;

    }
    public decimal PagamentoViaCartao(decimal total, int Parcelas, DateTime Vencimento)
    {
        try
        {
            IPagamento pagamento
        
            Console.WriteLine("Pagamento via Cartão selecionado.");
            if  (Vencimento < DateTime.Now)
            {
                Console.WriteLine("O pagamento expirou.");
            }
            Console.WriteLine("Escolha em quantas parcelas será feito o pagamento 1x-12x. Tendo juros a partir de 2x.");
            Parcelas = Console.ReadLine() !=null ? 1 : int.Parse(Console.ReadLine());
            if (Parcelas > 1 && Parcelas <= 12)
            {
                Console.WriteLine($"Dessa forma o pagamento será feito em {Parcelas} parcelas, com 10% de juros.");
                return pagamento.Valor += pagamento.Valor * 0.10m; // Adiciona 10% de taxa para 2 ou mais parcelas
            }
            else if (Parcelas == 1)
            {
                Console.WriteLine($"Dessa forma o pagamento será feito em {Parcelas} parcelas e não vai ter juros.");
                return pagamento.Valor;
            }
            else
            {
                throw new ArgumentException("Número de parcelas inválido.");
            }
                
        }
        catch(ArgumentException ex)
        {
            throw new ArgumentException("Impossivel completar o pagamento." + ex.Message);
        }
    }
    public decimal PagamentoViaPix(decimal desconto, decimal total, DateTime Vencimento, bool SalvarPagamento) 
    {
        IPagamento pagamento = new PagamentoViaPix
        {
            Desconto = desconto,
            Valor = total,
            Vencimento = Vencimento
        };
        try
        {
            Console.WriteLine("Pagamento via Pix selecionado.");
            if (Vencimento <= DateTime.Now.AddMinutes(30))
            {
                return pagamento.Valor -= pagamento.Valor * 0.10m; //Desconto de 10%.
            }
            else
            {
                throw new ArgumentException("Pagamento indisponivel.");
            }
        }
        catch(ArgumentException ex)
        {
            throw new ArgumentException("Por favor, tente outra vez." + ex.Message);
        }

    }
    public decimal PagamentoViaBoleto(decimal valor, DateTime Vencimento, bool SalvarPagamento)
    {
        IPagamento pagamento = new PagamentoViaBoleto
        {
            Valor = valor,
            Vencimento = Vencimento
        };

        Console.WriteLine("Pagamento via Boleto selecionado.");
        if (Vencimento > DateTime.Now.AddDays(3))
        {
            Console.WriteLine("Boleto expirou.");
            return 0m;
        }
        else
        {
            Console.WriteLine("Boleto disponivel para pagamento.");
            _pagamentoRepository.SalvarPagamento((Pagamento)pagamento);
            return pagamento.Valor;
        }
    }

    private bool IsPagamentoInvalido(Pagamento pagamento)
    {
        if (pagamento == null || pagamento.Valor <= 0)
        {
            return true;
        }
        return false;
    }
}*/