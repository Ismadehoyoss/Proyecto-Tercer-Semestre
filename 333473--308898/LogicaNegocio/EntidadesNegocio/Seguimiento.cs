using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Seguimiento
    {
        public int Id { get; set; }
        public string Comentario { get; set; }

        public DateTime FechaHora { get; set; }

		public Usuario Usuario { get; set; }
		public int UsuarioId { get; set; }
		public Envio Envio { get; set; }
		public int EnvioId { get; set; }


		public Seguimiento(string comentario, DateTime fechaHora, int envioId, int usuarioId)
		{
			Comentario = comentario;
			FechaHora = fechaHora;
			EnvioId = envioId;
			UsuarioId = usuarioId;
		}
		

		private Seguimiento() { }
	}
}
