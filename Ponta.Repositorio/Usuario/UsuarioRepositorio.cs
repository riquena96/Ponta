using Ponta.Dominio;
using Ponta.Infra.Session;
using Ponta.Repositorio.Generic;
using Ponta.Repositorio.Interface;
using System;

namespace Ponta.Repositorio;

public class UsuarioRepositorio : GenericRepositorio<Usuario, Guid>, IUsuarioRepositorio
{
    private readonly Context _context;

    public UsuarioRepositorio(Context context, ISessionService sessionService) : base(context, sessionService)
    {
        _context = context;
    }

}
