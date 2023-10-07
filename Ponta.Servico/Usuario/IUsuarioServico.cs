using Ponta.Dominio;
using Ponta.Servico.Generic;
using Ponta.Servico.ViewModel;
using System;
using System.Threading.Tasks;

namespace Ponta.Servico.Interface;

public interface IUsuarioServico : IGenericServico<Usuario, Guid>
{
    Task<AutenticarViewModel> Autenticar(AutenticarPropertiesViewModel usuario);
}
