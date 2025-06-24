using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Usuario
{
	public class UsuarioLogueadoDTO
	{
		public string Token { get; set; }
		public string Rol { get; set; }
		public string Email { get; set; }
		public int Id { get; set; }
	}
}
