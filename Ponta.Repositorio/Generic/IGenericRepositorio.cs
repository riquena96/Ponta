using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponta.Repositorio.Generic;

public interface IGenericRepositorio<TEntity, TId>
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(TId id);
    void Update(TEntity entity);
    Task Create(TEntity entity);
    void Delete(TEntity entity);
}
