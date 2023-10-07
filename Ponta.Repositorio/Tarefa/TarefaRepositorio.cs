using Ponta.Dominio;
using Ponta.Infra.Session;
using Ponta.Repositorio.Generic;
using Ponta.Repositorio.Interface;
using System;

namespace Ponta.Repositorio;

public class TarefaRepositorio : GenericRepositorio<Tarefa, Guid>, ITarefaRepositorio
{
    private readonly Context _context;

	public TarefaRepositorio(Context context, ISessionService sessionService) : base(context, sessionService)
	{
		_context = context;
	}


}
