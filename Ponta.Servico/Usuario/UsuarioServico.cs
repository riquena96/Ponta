using Ponta.Dominio;
using Ponta.Infra.Jwt;
using Ponta.Repositorio.Interface;
using Ponta.Servico.Generic;
using Ponta.Servico.Interface;
using Ponta.Servico.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponta.Servico;

public class UsuarioServico : GenericServico<Usuario, Guid>, IUsuarioServico
{
    private readonly IUsuarioRepositorio _repositorio;
	private readonly IUtils _utils;

    public UsuarioServico(IUsuarioRepositorio repositorio, IUtils utils) : base(repositorio)
	{
        _repositorio = repositorio;
		_utils = utils;
	}

	public async Task<AutenticarViewModel> Autenticar(AutenticarPropertiesViewModel usuario)
	{
		IEnumerable<Usuario> usuarios = await _repositorio.GetAll();

		if (!usuarios.Any())
		{
			return null;
		}

        usuario.Password = _utils.GerarHashMd5(usuario.Password);

        Usuario user = usuarios.FirstOrDefault(x => x.Login == usuario.Login && x.Password == usuario.Password);

		if (user == null)
			return null;

        string token = _utils.GenerateJwtToken(user);

		AutenticarViewModel viewModel = new AutenticarViewModel()
		{
			Id = user.Id,
			Nome = user.Nome,
			Login = user.Login,
			Token = token
		};

        return viewModel;
    }

	public override async Task Create(Usuario usuario)
	{
		usuario.Password = _utils.GerarHashMd5(usuario.Password);

        await _repositorio.Create(usuario);
    }

}
