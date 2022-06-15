using nextapp.Models;
using System.Collections.Generic;
using System.Linq;

namespace nextapp.Access
{
    public class AccessAuth
    {

        public List<Usuario> ListAuth()
        {
            return new List<Usuario>
            {
                new Usuario { nombre = "Administrator", usuario = "administrador", contrasena = "123", Roles = new string[] { "administrador" } },
                new Usuario { nombre = "Invitado", usuario = "invitado", contrasena = "123", Roles = new string[] { "invitado" } }
            };
        }

        public Usuario ValidarUsuario(string _usuario,  string _contrasena)
        {
            return ListAuth().Where(item => item.usuario == _usuario && item.contrasena == _contrasena).FirstOrDefault();
        }

    }
}
