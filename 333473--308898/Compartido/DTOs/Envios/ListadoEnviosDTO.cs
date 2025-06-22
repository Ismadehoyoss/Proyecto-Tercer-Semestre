using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envios
{
	public class ListadoEnviosDTO
	{
		public int Id { get; set; }
		public string NroTracking { get; set; }
		public int Peso { get; set; }
		public string FuncionarioNombre { get; set; }
		public string ClienteNombre { get; set; }
		public Estado Estado { get; set; }

		public DateTime FechaEntrega { get; set; }
	}
}
