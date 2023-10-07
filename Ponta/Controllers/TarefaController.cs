using Microsoft.AspNetCore.Mvc;
using Ponta.Dominio;
using Ponta.Dominio.Enum;
using Ponta.Servico;
using Ponta.WebApi.Generic;
using System.Net;

namespace Ponta.WebApi.Controllers;

public class TarefaController : GenericController<Tarefa, Guid>
{
    private readonly ITarefaServico _servico;

	public TarefaController(ITarefaServico servico) : base(servico)
	{
		_servico = servico;
	}

	[HttpGet("GetByStatus/{status}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<IEnumerable<Tarefa>> GetAll(TarefaStatus status)
    {
        return await _servico.GetByStatus(status);
    }

}
