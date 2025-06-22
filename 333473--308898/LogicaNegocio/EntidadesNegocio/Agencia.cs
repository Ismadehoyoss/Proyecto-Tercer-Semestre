using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
	public class Agencia
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string DireccionPostal { get; set; }
		public Ubicacion Ubicacion { get; set; }

        public Agencia(string nombre, string direccionPostal, Ubicacion ubicacion)
        {
            Nombre = nombre;
            DireccionPostal = direccionPostal;
            Ubicacion = ubicacion;
        }

		protected Agencia() { }
	}
}
