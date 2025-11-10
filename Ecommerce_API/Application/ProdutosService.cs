using Application.DTOs;
using Domain.Entidades;
using Domain.Interfaces;

namespace Application;

public class ProdutosService
{
    private IProdutoRepository _produtoRepository;

    public ProdutosService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    public void Incluir(ProdutoDTO produtoDTO)
    {
        Produto produto = produtoDTO.Mapear();
        _produtoRepository.Incluir(produto);
    }

    public List<ProdutoDTO> Listar()
    {
        List<Produto> listaProdutos = _produtoRepository.Listar();

        List<ProdutoDTO> listaProdutosDTO = new List<ProdutoDTO>();

        foreach (Produto produto in listaProdutos)
        {
            ProdutoDTO dto = new ProdutoDTO { Id = produto.Id, Nome = produto.Nome };
            listaProdutosDTO.Add(dto);
        }

        return listaProdutosDTO;
    }
}
