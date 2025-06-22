using Compartido.DTOs.Envios;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
	public class BuscarEnvios : IBuscarEnvios
	{
		private IRepositorioEnvio RepoEnvio { get; set; }

		public BuscarEnvios(IRepositorioEnvio repoEnvio)
		{
			RepoEnvio = repoEnvio;
		}

		public ListadoEnviosDTO Ejecutar(string NroTracking)
		{
			return EnvioMapper.EnvioToListadoDTO
				(RepoEnvio.FindByNroTracking(NroTracking));
		}
		
	}
}
