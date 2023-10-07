using Ponta.Dominio;
using Ponta.Dominio.Enum;
using Ponta.Infra.Session;
using Ponta.Repositorio.Interface;
using Ponta.Servico.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponta.Servico;

public class TarefaServico : GenericServico<Tarefa, Guid>, ITarefaServico
{
    private readonly ITarefaRepositorio _repositorio;
	private readonly ISessionService _sessionService;

	public TarefaServico(ITarefaRepositorio repositorio, ISessionService sessionService) : base(repositorio)
	{
		_repositorio = repositorio;
		_sessionService = sessionService;
	}

	public override async Task Update(Tarefa tarefa)
	{
		Tarefa task = await _repositorio.GetById(tarefa.Id);

		if (task == null)
			throw new Exception("Tarefa não encontrada");

		if (task.IdUsuarioCriador != _sessionService.usuario.Id)
			throw new Exception("Usuário não autorizado para alterar essa tarefa");

		task.Status = tarefa.Status;
		task.Titulo = tarefa.Titulo;
		task.Descricao = tarefa.Descricao;

		_repositorio.Update(task);
	}

    public override async Task Delete(Guid id)
    {
        Tarefa tarefa = await _repositorio.GetById(id);

        if (tarefa == null)
            throw new Exception("Tarefa não encontrada");

        if (tarefa.IdUsuarioCriador != _sessionService.usuario.Id)
            throw new Exception("Usuário não autorizado para alterar essa tarefa");

        _repositorio.Delete(tarefa);
    }

	public async Task<IEnumerable<Tarefa>> GetByStatus(TarefaStatus status)
	{
		var tarefas = await _repositorio.GetAll();

		if (tarefas == null)
			return null;

		return tarefas.Where(x => x.Status == status).ToList();
	}

}
