namespace Domain.Entidades;
public class Endereco
{
    private string _estado;
    public string Estado
    {
        get { return _estado; }
        set
        {
            _estado = value?.ToUpper();
        }
    }
    private string _cidade;
    public string Cidade
    {
        get { return _cidade; }
        set
        {
            _cidade = value?.ToUpper();
        }
    }
}
