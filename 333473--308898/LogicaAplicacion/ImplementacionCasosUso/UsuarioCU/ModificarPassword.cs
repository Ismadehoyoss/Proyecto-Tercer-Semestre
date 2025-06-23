using Compartido.DTOs.Usuario;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class ModificarPassword : IModificarPassword
    {
        private IRepositorioUsuario RepoUsuario { get; set; }

        public ModificarPassword(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario=repoUsuario;
        }

        public void Ejecutar(CambioPasswordDTO dto)
        {
            Usuario userBuscado = RepoUsuario.FindByEmail(dto.Email);
            if(userBuscado == null)
            {
                throw new UsuarioException("Datos Incorrectos"); 
            }
            if(userBuscado.Contraseña != dto.PasswordActual)
            {
                throw new UsuarioException("Contraseña Invalida"); 
            }
            userBuscado.Contraseña = dto.PasswordNueva;

            RepoUsuario.Update(userBuscado);

        }
    }
}
