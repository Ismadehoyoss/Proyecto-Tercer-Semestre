using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
   public class Urgente : Envio
    {
        public string DireccionPostal { get; set; }
        public Boolean Entregado { get; set; }
        public int TiempoEntrega { get; set; }

		public Urgente(string numeroTracking,Usuario funcionario,Usuario cliente,int peso,Estado estado,List<Seguimiento> seguimientos,string direccionPostal,bool entregado,int tiempoEntrega, DateTime fechaEstimada): 
			base(numeroTracking, funcionario, cliente, peso, estado, fechaEstimada)
		{
			DireccionPostal = direccionPostal;
			Entregado = entregado;
			TiempoEntrega = tiempoEntrega;
		}
		protected Urgente() { }
		

	}
}
