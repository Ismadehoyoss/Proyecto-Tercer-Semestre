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
		public UsuarioDTO Ejecutar(string Email, string contraseña)
		{
			if(string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(contraseña))
			{
				throw new ArgumentNullException("Email y Contraseña son requeridos");
			}

			Usuario usuario = RepoUsuario.FindByEmail(Email);
			if(usuario == null)
			{
				throw new UsuarioException("Usuario no encontrado");
			}

			return UsuarioMapper.UsuarioToUsuarioDTO(usuario);
		}

	}
}
