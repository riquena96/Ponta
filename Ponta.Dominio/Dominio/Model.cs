using System.Text.Json.Serialization;

namespace Ponta.Dominio;

public class Model
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public Guid IdUsuarioCriador { get; set; }
    public DateTime DataCriacao { get; set; }
    [JsonIgnore]
    public Guid IdUsuarioModificador { get; set; }
    [JsonIgnore]
    public DateTime DataModificacao { get; set; }
}
