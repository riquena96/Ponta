using Ponta.Repositorio.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponta.Servico.Generic;

public class GenericServico<TEntity, TId> : IGenericServico<TEntity, TId>
    where TEntity : class
{
    private readonly IGenericRepositorio<TEntity, TId> _repositorio;

    public GenericServico(IGenericRepositorio<TEntity, TId> repositorio)
    {
        _repositorio = repositorio;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
        => await _repositorio.GetAll();

    public virtual async Task<TEntity> GetById(TId id)
        => await _repositorio.GetById(id);

    public virtual async Task Update(TEntity entity)
    {
        _repositorio.Update(entity);
    }

    public virtual async Task Create(TEntity entity)
    {
        await _repositorio.Create(entity);
    }

    public virtual async Task Delete(TId id)
    {
        var entity = await _repositorio.GetById(id);
        if (entity != null)
            _repositorio.Delete(entity);
    }

}
