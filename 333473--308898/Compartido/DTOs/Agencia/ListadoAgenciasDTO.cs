using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Agencia
{
	public class ListadoAgenciasDTO
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string DireccionPostal { get; set; }

		public Ubicacion Ubicacion { get; set; }	
	}
}
