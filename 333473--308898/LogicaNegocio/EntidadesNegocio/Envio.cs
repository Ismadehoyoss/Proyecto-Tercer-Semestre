using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaNegocio.EntidadesNegocio
{
    public abstract class Envio
    {

        public int Id { get; set; }

        public string NroTracking { get; set; }

        public Usuario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
        public Usuario Cliente { get; set; }
        public int ClienteId { get; set; }

        public int Peso { get; set; }

        public Estado Estado { get; set; }

        public IEnumerable<Seguimiento> Seguimientos { get; set; }

        public DateTime? FechaEntrega { get; set; }
        protected Envio() { }

        public Envio(string nroTracking, Usuario funcionario, Usuario cliente, int peso, Estado estado)
        {
            NroTracking = nroTracking;
            Funcionario = funcionario;
            Cliente = cliente;
            Peso = peso;
            Estado = estado;
        }
    }
		public enum Estado
		{
			En_Proceso,
			Finalizado
		}
	}
 
