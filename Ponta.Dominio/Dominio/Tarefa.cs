using Ponta.Dominio.Enum;

namespace Ponta.Dominio;

public class Tarefa : Model
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public TarefaStatus Status { get; set; }
}
