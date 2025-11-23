namespace Domain.Entidades;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public Endereco EnderecoCliente { get; set; } = new();
    public  string Endereco { get; set; }
}
