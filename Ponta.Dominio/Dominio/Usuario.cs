namespace Ponta.Dominio;

public class Usuario : Model
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
