using System.ComponentModel.DataAnnotations;

namespace Ponta.Servico.ViewModel;

public class AutenticarPropertiesViewModel
{
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
}
