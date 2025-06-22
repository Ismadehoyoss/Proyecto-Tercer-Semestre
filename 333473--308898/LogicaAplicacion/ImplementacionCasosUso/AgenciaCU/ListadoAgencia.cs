using Compartido.DTOs.Agencia;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.AgenciaCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.AgenciaCU
{
	public class ListadoAgencia : IListadoAgencias
	{
		private IRepositorioAgencia RepoAgencia { get; set; }

		public ListadoAgencia(IRepositorioAgencia repoAgencia)
		{
			RepoAgencia = repoAgencia;
		}

		public IEnumerable<ListadoAgenciasDTO> Ejecutar()
		{

			IEnumerable<ListadoAgenciasDTO> agenciasDTO = new List<ListadoAgenciasDTO>();
			IEnumerable<Agencia> agencias = RepoAgencia.FindAll().ToList();
			agenciasDTO = AgenciaMapper.ListadoAgenciaToListadoAgenciaDTO(agencias);
			return agenciasDTO;
		}
	}
}
