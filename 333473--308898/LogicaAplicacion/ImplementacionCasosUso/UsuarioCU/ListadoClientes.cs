using Compartido.DTOs.Usuario;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
	public class ListadoClientes : IListadoCliente
	{
		
			private IRepositorioUsuario RepoUsuario { get; set; }

			public ListadoClientes(IRepositorioUsuario repousuario)
			{
				RepoUsuario = repousuario;
			}

			public IEnumerable<ListadoUsuariosDTO> Ejecutar()
			{
				
				IEnumerable<Usuario> usuarios = RepoUsuario.FindByRolCliente().ToList();
				IEnumerable<ListadoUsuariosDTO> usuariosDTO = UsuarioMapper.ListadoUsuarioToListadoUsuarioDTO(usuarios);
				return usuariosDTO;

			}
		
	}
}
