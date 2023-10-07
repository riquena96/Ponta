using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponta.Servico.Generic;

public interface IGenericServico<TEntity, TId>
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(TId id);
    Task Update(TEntity entity);
    Task Create(TEntity entity);
    Task Delete(TId id);
}
