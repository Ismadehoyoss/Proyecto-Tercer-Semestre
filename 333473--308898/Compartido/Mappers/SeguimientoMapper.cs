using Compartido.DTOs.Envios;
using Compartido.DTOs.Seguimiento;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
	public class SeguimientoMapper
	{
		public static IEnumerable<SeguimientoDTO> ListadoSeguimientoToListadoSeguimientoDTO
			(IEnumerable<Seguimiento> seguimientos)
		{
			IEnumerable<SeguimientoDTO> seguimientoDTOs = new List<SeguimientoDTO>();
			seguimientoDTOs = seguimientos.Select(c => new SeguimientoDTO()
			{
				EnvioId = c.EnvioId,
				Comentario = c.Comentario,
				FechaHora = c.FechaHora,
				UsuarioId = c.UsuarioId


			});
			return seguimientoDTOs;
		}
	}
}
