using Ponta.Dominio;

namespace Ponta.Infra.Jwt;

public interface IUtils
{
    string GenerateJwtToken(Usuario usuario);
    Guid? ValidateJwtToken(string? token);
    string GerarHashMd5(string input);
}
