namespace Domain.Entidades;

public class Produto
{
    private string _nome;
    public int Id { get; set; }
    public string Nome
    {
        get { return _nome; }
        set
        {
            _nome = value?.ToUpper();
        }
    }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}
