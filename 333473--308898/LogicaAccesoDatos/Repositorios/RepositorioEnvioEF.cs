using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
	public class RepositorioEnvioEF : IRepositorioEnvio
	{

		private DemoContext Contexto { get; set; }

		public RepositorioEnvioEF(DemoContext contexto)
		{
			Contexto = contexto;
		}
		public void Add(Envio item)
		{
			Envio envioEncontrado = FindByNroTracking(item.NroTracking);
			if (envioEncontrado == null)
			{
				Contexto.Envios.Add(item);
				Contexto.SaveChanges();
			}
			else
			{
				throw new Exception("Ya existe un envio con ese numero de tracking");
			}

		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Envio> FindAll()
		{
			return Contexto.Envios.Include(e => e.Funcionario).Include(e => e.Cliente);
		}

		public Envio FindById(int id)
		{
			return Contexto.Envios.Where(c => c.Id == id).Include(c => c.Seguimientos).SingleOrDefault();
		}

		public void Update(Envio item)
		{
			Envio envioEncontrado = FindByNroTracking(item.NroTracking);

			if (envioEncontrado != null)
			{
				envioEncontrado.FuncionarioId = item.FuncionarioId;
				envioEncontrado.ClienteId = item.ClienteId;
				envioEncontrado.Estado = item.Estado;
				envioEncontrado.Peso = item.Peso;
				envioEncontrado.FechaEntrega = item.FechaEntrega;

				
				Contexto.SaveChanges();
			}
			else
			{
				throw new Exception("No se encontró el envío a actualizar.");
			}
		}

		public Envio FindByNroTracking(string NroTracking)
		{
			return Contexto.Envios.Where(e => e.NroTracking == NroTracking).Include(e => e.Cliente).Include(e => e.Funcionario).SingleOrDefault();
		}

		public void FinalizarEnvio(string NroTracking)
		{
			Envio envio = FindByNroTracking(NroTracking);
			if (envio != null)
			{
				envio.Estado = Estado.Finalizado;
				envio.FechaEntrega = DateTime.Now;
				Contexto.SaveChanges();
			}
			else
			{
				throw new Exception("No se encontró el envío con el Numero de Tracking proporcionado.");
			}
		}

		public IEnumerable<Envio> FindByCliente(int clienteId)
		{
			return Contexto.Envios.Where(e => e.ClienteId == clienteId).OrderByDescending(e => e.FechaEntrega).Include(e => e.Funcionario).Include(e => e.Cliente).ToList();
		}


	}
}
