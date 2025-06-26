using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
   public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        Envio FindByNroTracking(string NroTracking);

		void FinalizarEnvio(string NroTracking);

		IEnumerable<Envio>FindByCliente(int clienteId);

		IEnumerable<Envio>FindByFechas(DateTime fechaInicio, DateTime fechaFin, int clienteId, Estado estado);

		IEnumerable<Envio>FindByComentario(string comentario, int clienteId);

	}
}
