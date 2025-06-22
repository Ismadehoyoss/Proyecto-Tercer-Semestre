using Compartido.DTOs.Envios;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
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

		public EnvioController(IListadoEnvios cUlistadoEnvios, IBuscarEnvios cUbuscarEnvios)
		{
			CUlistadoEnvios = cUlistadoEnvios;
			CUbuscarEnvios = cUbuscarEnvios;
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

		// GET api/<EnvioController>/5
		[HttpGet("{NroTracking}")]
		public IActionResult Get(string NroTracking)
		{
			//FindById
			try
			{

				if (NroTracking == null)
				{
					return BadRequest("El NroTracking no puede ser Nulo");
				}
				return Ok(CUbuscarEnvios.Ejecutar(NroTracking));
			}
			catch (Exception ex)
			{

				return StatusCode(500, "Datos Incorrectos");
			}
		}

		// POST api/<EnvioController>
		[HttpPost]
		public IActionResult Post([FromBody] AltaEnvioUrgenteDTO envioDTO)
		{
			//Add o Create
			try
			{
				if(envioDTO == null)
				{
					return BadRequest("Datos incorrectos");
				}
				return Ok(Post);
			}
			catch (Exception)
			{

				throw;
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
