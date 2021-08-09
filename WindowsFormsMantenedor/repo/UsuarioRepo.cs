using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsMantenedor.ef;

namespace WindowsFormsMantenedor.repo
{
    class UsuarioRepo
    {
        public static Usuarios ValidarUsuario(string usuario,string clave)
        {
            var usuarioEncontrado=new Usuarios();
            using(var contexto=new Model1Contexto())
            {
                usuarioEncontrado = contexto.Usuarios
                    .Where(u=>u.NombreUsuario==usuario)
                    .Where(u => u.Clave == clave)
                    .Include("Grupos")
                    .FirstOrDefault();

            }
            return usuarioEncontrado;
        }
    }
}
