using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using Compartido.DTOs.Usuario;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
	public class ListadoUsuarios:IListadoUsuarios
	{
		private IRepositorioUsuario RepoUsuario { get; set; }

        public ListadoUsuarios(IRepositorioUsuario repousuario)
		{
			RepoUsuario = repousuario;
		}

		public IEnumerable<ListadoUsuariosDTO> Ejecutar()
		{

			IEnumerable<ListadoUsuariosDTO> usuariosDTO = new List<ListadoUsuariosDTO>();
			IEnumerable<Usuario> usuarios = RepoUsuario.FindByRolFuncionario().ToList();
			usuariosDTO = UsuarioMapper.ListadoUsuarioToListadoUsuarioDTO(usuarios);
			return usuariosDTO;

		}
	}
}
