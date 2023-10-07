using Ponta.Dominio;
using Ponta.Repositorio.Generic;
using System;

namespace Ponta.Repositorio.Interface;

public interface ITarefaRepositorio : IGenericRepositorio<Tarefa, Guid>
{
}
