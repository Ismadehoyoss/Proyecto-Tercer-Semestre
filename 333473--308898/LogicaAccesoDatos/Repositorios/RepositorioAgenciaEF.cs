using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
	public class RepositorioAgenciaEF : IRepositorioAgencia
	{
		private DemoContext Contexto { get; set; }

		public RepositorioAgenciaEF(DemoContext contexto)
		{
			Contexto = contexto;
		}
		public void Add(Agencia item)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Agencia> FindAll()
		{
			return Contexto.Agencias;
		}

		public Agencia FindById(int id)
		{
			return Contexto.Agencias.Find(id);
		}

		public void Update(Agencia item)
		{
			throw new NotImplementedException();
		}
	}
}
