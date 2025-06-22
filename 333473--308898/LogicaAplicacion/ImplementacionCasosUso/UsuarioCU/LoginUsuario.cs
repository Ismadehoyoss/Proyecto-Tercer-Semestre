using Compartido.DTOs.Usuario;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
	public class LoginUsuario : ILoginUsuario
	{
		private IRepositorioUsuario RepoUsuario { get; set; }

		public LoginUsuario(IRepositorioUsuario repoUsuario)
		{
			RepoUsuario = repoUsuario;
		}

		public UsuarioLogueadoDTO Ejecutar(UsuarioDTO usuariodto)
		{
			Usuario usuario = RepoUsuario.FindByEmailAndPassword(usuariodto.Email, usuariodto.Password);
			if (usuario == null)
			{
				throw new UsuarioException("Usuario o contraseña incorrectos");
			}
			return UsuarioMapper.UsuarioToUsuarioLogueadoDTO(usuario);
		}
	}
}
