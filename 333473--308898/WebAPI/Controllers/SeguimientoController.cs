using Compartido.DTOs.Envios;
using Compartido.DTOs.Seguimiento;
using LogicaAplicacion.InterfacesCasosUso.SeguimientoCU;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SeguimientoController : ControllerBase
	{
		public IListadoSeguimientos ListadoSeguimientos { get; set; }
		public SeguimientoController(IListadoSeguimientos listadoSeguimientos)
		{
			ListadoSeguimientos = listadoSeguimientos;
		}
		// GET: api/<SeguimientoController>
		[Authorize(Roles = "Cliente")]
		[HttpGet("envio/{envioId}")]
		public IActionResult GetSeguimientosPorEnvio(int envioId)
		{
			try
			{
				List<SeguimientoDTO> seguimientos = ListadoSeguimientos.Ejecutar(envioId).ToList();
				if (seguimientos == null || seguimientos.Count == 0)
				{
					return NotFound("No se encontraron seguimientos para este envio.");
				}
				else
				{
					return Ok(seguimientos);
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Error interno");
			}

		}

		// GET api/<SeguimientoController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<SeguimientoController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<SeguimientoController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<SeguimientoController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
