using Ponta.Dominio;

namespace Ponta.Infra.Session;

public interface ISessionService
{
    Usuario? usuario { get; set; }
    bool FoiDefinida { get; set; }

    void DefinirSessao(Usuario usuario);
}
