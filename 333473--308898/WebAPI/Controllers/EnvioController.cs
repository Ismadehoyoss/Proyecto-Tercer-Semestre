using Compartido.DTOs.Envios;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EnvioController : ControllerBase
	{
		public IListadoEnvios CUlistadoEnvios { get; set; }

		public IBuscarEnvios CUbuscarEnvios { get; set; }

		public IAltaEnvioComun CUaltaEnvioComun { get; set; }
		public IAltaEnvioUrgente CUaltaEnvioUrgente { get; set; }
		public IListadoEnviosxFecha CUlistadoxFechas { get; set; }

		public IListadoEnviosxComentario CUlistadoEnviosxComentarios { get; set; }

		public IListadoEnviosClienteLogueado CUlistadoEnviosClienteLogueado { get; set; }
		public EnvioController(
		IListadoEnvios cUlistadoEnvios,
		IBuscarEnvios cUbuscarEnvios,
		IAltaEnvioUrgente cUaltaEnvioUrgente,
		IAltaEnvioComun cUaltaEnvioComun,
		IListadoEnviosClienteLogueado cUlistadoEnviosClienteLogueado,
		IListadoEnviosxFecha cUlistadoxFechas,
		IListadoEnviosxComentario cUlistadoxComentarios)
		{
			CUlistadoEnvios = cUlistadoEnvios;
			CUbuscarEnvios = cUbuscarEnvios;
			CUaltaEnvioUrgente = cUaltaEnvioUrgente;
			CUaltaEnvioComun = cUaltaEnvioComun;
			CUlistadoEnviosClienteLogueado = cUlistadoEnviosClienteLogueado;
			CUlistadoxFechas = cUlistadoxFechas;
			CUlistadoEnviosxComentarios = cUlistadoxComentarios;
		}


		// GET: api/<EnvioController>
		[HttpGet]
		public IActionResult Get()
		{
			//FindAll
			try
			{
				List<ListadoEnviosDTO> envios = CUlistadoEnvios.Ejecutar().ToList();
				if(envios == null || envios.Count == 0)
				{
					return NotFound("No se encontraron envíos.");
				}
				else
				{
					return Ok(envios);
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Error interno");
			}

		}
		[Authorize(Roles = "Cliente")]
		[HttpGet("cliente/{clienteId}")]
		public IActionResult GetPorCliente(int clienteId)
		{
			//FindAll por Cliente Logueado
			try
			{
				List<ListadoEnviosDTO> envios = CUlistadoEnviosClienteLogueado.Ejecutar(clienteId).ToList();
				if (envios == null || envios.Count == 0)
				{
					return NotFound("No se encontraron envíos para el cliente logueado.");
				}
				else
				{
					return Ok(envios);
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Error interno");
			}
		}
		[Authorize(Roles = "Cliente")]
		[HttpGet("porFechas")]
		public IActionResult GetEnviosPorFechas(DateTime fechaInicio, DateTime fechaFin, int clienteId, Estado estado)
		{
			try
			{
				if (fechaInicio == DateTime.MinValue || fechaFin == DateTime.MinValue)
					return BadRequest("Las fechas no pueden estar vacías.");

				if (fechaInicio > fechaFin)
					return BadRequest("La fecha de inicio no puede ser mayor que la fecha de fin.");

				// Ejecutar consulta filtrando por fechas y cliente
				List<ListadoEnviosDTO> envios = CUlistadoxFechas.Ejecutar(fechaInicio, fechaFin, clienteId,estado).ToList();

				if (envios == null || envios.Count == 0)
					return NotFound("No se encontraron envíos en el rango de fechas para este cliente.");

				return Ok(envios);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Error interno");
			}
		}
		[Authorize(Roles = "Cliente")]
		[HttpGet("porComentario")]
		public IActionResult GetEnviosPorComentario(string comentario, int clienteId)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(comentario))
					return BadRequest("Debe ingresar una palabra a buscar.");

				List<ListadoEnviosDTO> envios = CUlistadoEnviosxComentarios.Ejecutar(comentario, clienteId).ToList();

				if (!envios.Any())
					return NotFound("No se encontraron envíos con ese comentario.");

				return Ok(envios);
			}
			catch (Exception)
			{
				return StatusCode(500, "Error interno.");
			}
		}

		// GET api/<EnvioController>/5
		[HttpGet("FindByNroTracking/{nroTracking}")]
		public IActionResult Get(string nroTracking)
		{
			//FindById
			try
			{
				ListadoEnviosDTO envios = CUbuscarEnvios.Ejecutar(nroTracking);
				if (envios == null)
				{
					return NotFound("No se encontraron envíos para este numero de Tracking.");
				}
				else
				{
					return Ok(envios);
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Error interno");
			}
		}

		// POST api/<EnvioController>
		[HttpPost("urgente")]
		public IActionResult PostUrgente([FromBody] AltaEnvioUrgenteDTO envioDTO)
		{
			//Add o Create
			try
			{
				if (envioDTO == null)
				{
					return BadRequest("Datos incorrectos");
				}

				CUaltaEnvioUrgente.Ejecutar(envioDTO);
				return Ok("Envío urgente registrado correctamente.");
			}
			catch (Exception)
			{
				return StatusCode(500, "Error interno al registrar envío urgente.");
			}
		}

		[HttpPost("comun")]
		public IActionResult PostComun([FromBody] AltaEnvioComunDTO envioDTO)
		{
			try
			{
				if (envioDTO == null)
				{
					return BadRequest("Datos incorrectos");
				}

				CUaltaEnvioComun.Ejecutar(envioDTO);
				return Ok("Envío común registrado correctamente.");
			}
			catch (Exception)
			{
				return StatusCode(500, "Error interno al registrar envío común.");
			}
		}

		// PUT api/<EnvioController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
			//Update
		}

		// DELETE api/<EnvioController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			//Delete o Remove
		}
	}
}
