using Ponta.Dominio;
using Ponta.Dominio.Enum;
using Ponta.Servico.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ponta.Servico;

public interface ITarefaServico : IGenericServico<Tarefa, Guid>
{
    Task<IEnumerable<Tarefa>> GetByStatus(TarefaStatus status);
}
