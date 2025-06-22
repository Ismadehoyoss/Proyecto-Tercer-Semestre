using Compartido.DTOs.Agencia;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
	public class AgenciaMapper
	{
		public static IEnumerable<ListadoAgenciasDTO> ListadoAgenciaToListadoAgenciaDTO
			(IEnumerable<Agencia> agencias)
		{

			return agencias.Select(c => new ListadoAgenciasDTO()
			{
				Id = c.Id,
				Nombre = c.Nombre,
				DireccionPostal = c.DireccionPostal,
				Ubicacion = c.Ubicacion
			}).ToList();
		}
	}
}
