using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
	public class FinalizarEnvio : IFinalizarEnvio
	{
		private IRepositorioEnvio RepoEnvio { get; set; }
		public FinalizarEnvio(IRepositorioEnvio repoEnvio)
		{
			RepoEnvio = repoEnvio;
		}

		public void Ejecutar(string NroTracking)
		{
			if (string.IsNullOrEmpty(NroTracking))
			{
				throw new ArgumentNullException("Datos incorrectos");
			}
			Envio envio = RepoEnvio.FindByNroTracking(NroTracking);
			if (envio != null)
			{
				RepoEnvio.FinalizarEnvio(envio.NroTracking);
			}
			else
			{
				throw new ArgumentException("El envio no existe");
			}
		}

	}
}
