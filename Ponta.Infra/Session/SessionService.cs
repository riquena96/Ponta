using Ponta.Dominio;

namespace Ponta.Infra.Session;

public class SessionService : ISessionService
{
    public Usuario? usuario { get; set; }
    public bool FoiDefinida { get; set; }

    public void DefinirSessao(Usuario usuario)
    {
        this.FoiDefinida = false;
        this.usuario = usuario;

        if (this.usuario != null)
            this.FoiDefinida = true;
    }
}
