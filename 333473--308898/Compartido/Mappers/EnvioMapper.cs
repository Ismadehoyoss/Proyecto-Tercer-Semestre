using Compartido.DTOs.Envios;
using Compartido.DTOs.Seguimiento;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
	public class EnvioMapper
	{
		public static Comun ComunFromDTO(AltaEnvioComunDTO comunDTO, Usuario funcionario, Usuario cliente, Agencia agencia)
		{
			
			return new Comun(comunDTO.NumeroTracking,
					funcionario,
					cliente,
					comunDTO.Peso,
					Estado.En_Proceso,
					new List<Seguimiento>(),
					agencia,
					comunDTO.FechaEstimada);



		}
		public static Urgente UrgenteFromDTO(AltaEnvioUrgenteDTO urgenteDTO, Usuario funcionario, Usuario cliente)
		{

			return new Urgente(urgenteDTO.NumeroTracking,
				funcionario,
				cliente,
				urgenteDTO.Peso,
				urgenteDTO.Estado,
				new List<Seguimiento>(),
				urgenteDTO.DireccionPostal,
				urgenteDTO.Entregado,
				urgenteDTO.TiempoEntrega,
				urgenteDTO.FechaEstimada);

		}
		public static ListadoEnviosDTO EnvioToListadoDTO(Envio envio)
		{
			if (envio == null)
				return null;
			return new ListadoEnviosDTO()
			{
				Id = envio.Id,
				NroTracking = envio.NroTracking,
				Peso = envio.Peso,
				FuncionarioNombre = envio.Funcionario?.Nombre ?? "Sin funcionario",
				ClienteNombre = envio.Cliente?.Nombre ?? "Sin cliente",
				Estado = envio.Estado,
				FechaEntrega = envio.FechaEntrega ?? DateTime.MinValue,
				FechaEstimada = envio.FechaEstimada?? DateTime.MinValue
			};
		}

		
		public static IEnumerable<ListadoEnviosDTO> ListadoEnvioToListadoEnvioDTO
			(IEnumerable<Envio> envios)
		{
			IEnumerable<ListadoEnviosDTO> enviosDTOs = new List<ListadoEnviosDTO>();
			enviosDTOs = envios.Select(c => new ListadoEnviosDTO()
			{
				Id = c.Id,
				Peso = c.Peso,
				FuncionarioNombre = c.Funcionario.Nombre,
				ClienteNombre = c.Cliente.Nombre,
				Estado = c.Estado,
				NroTracking = c.NroTracking,
				FechaEntrega = c.FechaEntrega != null ? (DateTime)c.FechaEntrega : DateTime.MinValue,
				FechaEstimada = (DateTime)c.FechaEstimada


			});
			return enviosDTOs;
		}

		public static Seguimiento SeguimientoDTOtoSeguimiento(SeguimientoDTO seguimientoDTO, Usuario usuario)
		{
			if(seguimientoDTO == null)
			{
				throw new ArgumentNullException("Datos Incorrecotos");
			}
			return new Seguimiento(seguimientoDTO.Comentario,
				seguimientoDTO.FechaHora,seguimientoDTO.EnvioId,seguimientoDTO.UsuarioId);
				
		}


	}
}
