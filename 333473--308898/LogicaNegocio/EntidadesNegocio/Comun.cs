using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	public class Comun : Envio
	{
		public Agencia Agencia { get; set; }

		public Comun(string numeroTracking, Usuario funcionario, Usuario cliente, int peso, Estado estado, List<Seguimiento> seguimientos, Agencia agencia, DateTime fechaEstimada)
		: base( numeroTracking, funcionario, cliente, peso, estado, fechaEstimada)
		{
			Agencia = agencia;
		}

		protected Comun() { }

		
	}
}
