using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
	public class RepositorioSeguimientoEF : IRepositorioSeguimiento
	{
		private DemoContext Contexto { get; set; }

		public RepositorioSeguimientoEF(DemoContext contexto)
		{
			Contexto = contexto;
		}
		public void Add(Seguimiento item)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Seguimiento> FindAll()
		{
			throw new NotImplementedException();
		}

		public Seguimiento FindById(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(Seguimiento item)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Seguimiento> FindByEnvioId(int envioId)
		{
			return Contexto.Seguimientos
				.Where(s => s.EnvioId == envioId)
				.OrderByDescending(s => s.FechaHora)
				.ToList();

		}
	}
}
