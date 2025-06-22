using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Usuario
{
	public class ListadoUsuariosDTO
	{
		public int Id { get; set; }
		public string Ci { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Email { get; set; }
		public string Contraseña { get; set; }
		public Rol rol { get; set; }
	}

	
}
