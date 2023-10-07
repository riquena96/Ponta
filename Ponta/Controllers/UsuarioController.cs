using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ponta.Dominio;
using Ponta.Servico.Interface;
using Ponta.Servico.ViewModel;
using System.Net;

namespace Ponta.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioServico _servico;

	public UsuarioController(IUsuarioServico servico)
	{
		_servico = servico;
	}

	[AllowAnonymous]
	[HttpPost("Autenticar")]
	public async Task<IActionResult> Autenticar(AutenticarPropertiesViewModel usuario)
	{
        var response = await _servico.Autenticar(usuario);

        if (response == null)
            return BadRequest(new { message = "Login ou senha estão incorretas" });

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task Create(Usuario entity)
    {
        await _servico.Create(entity);
    }

}
