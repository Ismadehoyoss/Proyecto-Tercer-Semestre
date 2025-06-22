using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;
using Compartido.DTOs.Usuario;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
	public class RegistroUsuario : IRegistrarUsuario
	{
		private IRepositorioUsuario RepoUsuario { get; set; }

		public RegistroUsuario(IRepositorioUsuario repoUsuario)
		{
			RepoUsuario = repoUsuario;
		}

		public void Ejecutar(UsuarioDTO usuarioDTO)
		{
			if (usuarioDTO == null)
			{
				throw new ArgumentNullException("Datos Incorrectos");
			}
			Usuario usuario = UsuarioMapper.UsuarioFromUsuarioDTO(usuarioDTO);
			RepoUsuario.Add(usuario);
		}
	}
}
