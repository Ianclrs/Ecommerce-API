namespace Domain.Entidades;
public class Endereco
{
    public string Estado { get; set; } = string.Empty;

    public string Cidade { get; set; } = string.Empty;

    public List<Endereco> ListaDeEnderecos { get; set; } = new();

}
