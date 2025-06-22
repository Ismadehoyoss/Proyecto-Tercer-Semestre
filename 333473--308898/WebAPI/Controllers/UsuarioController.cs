using Compartido.DTOs.Usuario;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Autenticacion;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		public ILoginUsuario CULogin { get; set; }
		public UsuarioController(ILoginUsuario cULogin)
		{
			CULogin = cULogin;
		}
		[HttpPost]
		public IActionResult Login(UsuarioDTO usuarioDTO)
		{
			try
			{
				if(usuarioDTO == null)
				{
					return BadRequest("Datos Incorrectos");
				}
				UsuarioLogueadoDTO usuarioLogueado = CULogin.Ejecutar(usuarioDTO);
				if(usuarioLogueado != null)
				{
					usuarioLogueado.Token = ManejadorToken.CrearToken(usuarioLogueado);
					return Ok(usuarioLogueado);
				}
				else
				{
					return BadRequest("Usuario o contraseña incorrectos");
				}
			}
			catch (UsuarioException ex)
			{

				return NotFound(ex.Message);
			}
			catch(Exception ex)
			{
				return StatusCode(500, "Error");
			}
		}
	}
}
