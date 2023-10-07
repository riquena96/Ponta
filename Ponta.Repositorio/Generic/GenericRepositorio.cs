using Microsoft.EntityFrameworkCore;
using Ponta.Infra.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ponta.Repositorio.Generic;

public class GenericRepositorio<TEntity, TId> : IGenericRepositorio<TEntity, TId>
    where TEntity : class
{
    private readonly Context _context;
    private readonly ISessionService _sessionService;

    public GenericRepositorio(Context context, ISessionService sessionService)
    {
        _context = context;
        _sessionService = sessionService;
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetById(TId id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public void Update(TEntity entity)
    {
        PropertyInfo generico;
        PropertyInfo[] properties = entity.GetType().GetProperties();

        generico = properties.First(x => x.Name == "IdUsuarioModificador");
        generico.SetValue(entity, _sessionService.usuario.Id);

        generico = properties.First(x => x.Name == "DataModificacao");
        generico.SetValue(entity, DateTime.Now);

        _context.Set<TEntity>().Update(entity);

        _context.SaveChanges();
    }

    public async Task Create(TEntity entity)
    {
        PropertyInfo generico;
        PropertyInfo[] properties = entity.GetType().GetProperties();

        generico = properties.First(x => x.Name == "Id");
        generico.SetValue(entity, Guid.NewGuid());

        if (_sessionService.FoiDefinida)
        {
            generico = properties.First(x => x.Name == "IdUsuarioCriador");
            generico.SetValue(entity, _sessionService.usuario.Id);

            generico = properties.First(x => x.Name == "DataCriacao");
            generico.SetValue(entity, DateTime.Now);
        }
        
        await _context.Set<TEntity>().AddAsync(entity);

        _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);

        _context.SaveChanges();
    }

}
