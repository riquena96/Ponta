using Ponta.Dominio;
using Ponta.Infra.Jwt;
using Ponta.Infra.Session;
using Ponta.Servico.Interface;

namespace Ponta.WebApi;

public class AutorizacaoMiddleware
{
    private readonly RequestDelegate _request;

	public AutorizacaoMiddleware(RequestDelegate request)
	{
		_request = request;
	}

    public async Task Invoke(HttpContext context, IUtils utils, IUsuarioServico usuarioServico, ISessionService sessionService)
	{
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = utils.ValidateJwtToken(token);
        if (userId != null)
        {
            Usuario user = await usuarioServico.GetById(userId.Value);

            if (user != null)
            {
                context.Items["Usuario"] = user;

                sessionService.DefinirSessao(user);
            }
            
        }

        await _request(context);

    }
}
