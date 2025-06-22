using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
   public class EliminarUsuario : IEliminarUsuario
    {
        private IRepositorioUsuario RepoUsuario { get; set; }

        public EliminarUsuario
            (IRepositorioUsuario repositorioUsuario)
        {
            RepoUsuario = repositorioUsuario;
        }
        public void Ejecutar(int id)
        {
            RepoUsuario.Delete(id);
        }
    }
}
