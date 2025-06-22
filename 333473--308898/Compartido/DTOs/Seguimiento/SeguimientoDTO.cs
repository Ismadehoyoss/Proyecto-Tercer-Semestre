using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Seguimiento
{
	public class SeguimientoDTO
	{
		public string Comentario { get; set; }
		public DateTime FechaHora { get; set; }
		public int EnvioId { get; set; }         
		public int UsuarioId { get; set; }
	}
}
