using System.Runtime.InteropServices;
namespace Domain.Entidades;

public class Cliente
{
    public int Id { get; set; }

    private string _nome;
    public string Nome
    {
        get { return _nome; }
        set
        {
            _nome = value?.ToUpper();
        }
    }
    public string Senha { get; set; } = string.Empty;
    public Endereco EnderecoCliente { get; set; } = new();
}
