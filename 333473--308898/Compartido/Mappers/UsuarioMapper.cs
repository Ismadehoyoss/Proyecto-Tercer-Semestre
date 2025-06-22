using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs.Usuario;
using LogicaNegocio.EntidadesNegocio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Compartido.Mappers
{
	public class UsuarioMapper
	{
		public static Usuario UsuarioFromUsuarioDTO(UsuarioDTO usuarioDTO)
		{
			if(usuarioDTO == null)
			{
				throw new ArgumentNullException("Datos Incorrectos");
			}
		
			return new Usuario(usuarioDTO.Ci,
					  usuarioDTO.Nombre,
					  usuarioDTO.Apellido,
					  usuarioDTO.Email,
					  usuarioDTO.Contraseña,
					  usuarioDTO.Rol)
				;
		}

		public static IEnumerable<ListadoUsuariosDTO> ListadoUsuarioToListadoUsuarioDTO
			(IEnumerable<Usuario> usuarios)
		{
			
			return usuarios.Select(c => new ListadoUsuariosDTO()
			{
				Id = c.Id,
				Ci = c.Ci.Valor,
				Nombre = c.Nombre,
				Apellido = c.Apellido,
				Email = c.Email,
				Contraseña = c.Contraseña,
				rol = c.Rol
            }).ToList();
		}
		public static ListadoUsuariosDTO UsuarioToListadoUsuarioDTO
			(Usuario usuario)
		{
			return new ListadoUsuariosDTO()
			{
				Id = usuario.Id,
				Ci = usuario.Ci.Valor,
				Nombre = usuario.Nombre,
				Apellido = usuario.Apellido,
				Email = usuario.Email,
				Contraseña = usuario.Contraseña,
				rol = usuario.Rol
            };
		}

		public static Usuario UsuarioFromListadoUsuarioDTO(ListadoUsuariosDTO usuarioDTO)
		{
			if(usuarioDTO == null)
			{
				throw new ArgumentException("Datos Incorrectos");
			}
			return new Usuario(
				usuarioDTO.Ci,
				usuarioDTO.Nombre,
				usuarioDTO.Apellido,
				usuarioDTO.Email,
				usuarioDTO.Contraseña,
				usuarioDTO.rol);


        }

		public static UsuarioDTO UsuarioToUsuarioDTO(Usuario usuario)
		{
			if (usuario == null)
			{
				throw new ArgumentNullException("El usuario no puede ser nulo");
			}

			return new UsuarioDTO
			{
				Id = usuario.Id, 
				Ci = usuario.Ci.Valor, 
				Nombre = usuario.Nombre, 
				Apellido = usuario.Apellido, 
				Email = usuario.Email, 
				Contraseña = usuario.Contraseña, 
				Rol = usuario.Rol  
			};
		}
	}
}
