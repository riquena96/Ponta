using Microsoft.AspNetCore.Mvc;
using Ponta.Servico.Generic;
using System.Net;

namespace Ponta.WebApi.Generic;

[ApiController]
[Authorize]
[Route("[controller]")]
public class GenericController<TEntity, TId> : ControllerBase
    where TEntity : class
{
    private readonly IGenericServico<TEntity, TId> _servico;

    public GenericController(IGenericServico<TEntity, TId> servico)
    {
        _servico = servico;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _servico.GetAll();
    }

    [HttpGet("GetById/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<TEntity> GetById(TId id)
        => await _servico.GetById(id);

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task Create(TEntity entity)
    {
        await _servico.Create(entity);
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task Update(TEntity entity)
    {
        await _servico.Update(entity);
    }

    [HttpDelete("Delete/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task Delete(TId id)
        => await _servico.Delete(id);

}
