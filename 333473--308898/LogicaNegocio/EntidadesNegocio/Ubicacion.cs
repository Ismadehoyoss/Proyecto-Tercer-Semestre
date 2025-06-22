using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Ubicacion
    {
		public int Id { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }

		public Ubicacion(double latitud, double longitud)
		{
			Latitud = latitud;
			Longitud = longitud;
		}

		protected Ubicacion() { }
	}
}
