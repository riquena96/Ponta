using Ponta.Dominio;
using System;

namespace Ponta.Servico.ViewModel;

public class AutenticarViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Token { get; set; }

}
