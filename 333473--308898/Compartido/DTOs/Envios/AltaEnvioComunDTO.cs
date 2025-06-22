using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envios
{
	public class AltaEnvioComunDTO
	{
		public string NumeroTracking { get; set; }
		public int Peso { get; set; }
		public int FuncionarioId { get; set; }
		public int ClienteId { get; set; }
		public int AgenciaId { get; set; }
		public Estado Estado { get; set; }
	}
}
