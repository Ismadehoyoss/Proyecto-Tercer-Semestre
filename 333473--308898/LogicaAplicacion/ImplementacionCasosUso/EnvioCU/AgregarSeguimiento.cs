using Compartido.DTOs.Seguimiento;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
	public class AgregarSeguimiento : IAgregarSeguimiento
	{
		public IRepositorioEnvio RepoEnvio { get; set; }

		public IRepositorioUsuario RepoUsuario { get; set; }

		public AgregarSeguimiento(IRepositorioEnvio repoEnvio, IRepositorioUsuario repoUsuario)
		{
			RepoEnvio = repoEnvio;
			RepoUsuario = repoUsuario;
		}

		public void Ejecutar(SeguimientoDTO seguimientoDTO)
		{
			Envio envio = RepoEnvio.FindById(seguimientoDTO.EnvioId);
			Usuario usuario = RepoUsuario.FindById(seguimientoDTO.UsuarioId);
			Seguimiento seguimientos = EnvioMapper.SeguimientoDTOtoSeguimiento(seguimientoDTO,usuario);
			List<Seguimiento> listaSeguimientos = envio.Seguimientos.ToList();
			listaSeguimientos.Add(seguimientos);
			envio.Seguimientos = listaSeguimientos;
			if (seguimientos != null)
			{
				RepoEnvio.Update(envio);


			}
			else
			{
				throw new EnvioException("No se encontro un envio con ese numero de tracking");
			}


		}
	}
}
