using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsMantenedor.ef;

namespace WindowsFormsMantenedor.repo
{
    class ClienteRepo
    {
        public static List<Clientes> ListarTodo()
        {
            var listado=new List<Clientes>();
            using(var contexto=new Model1Contexto())
            {
               listado=contexto
                    .Clientes
                    .Include("Companias")
                    .ToList();
            }

            return listado;
        }
        public static Clientes Obtener(int id)
        {
            var cliente = new Clientes();
            using (var contexto = new Model1Contexto())
            {
                cliente = contexto
                     .Clientes
                     .Include("Companias")
                     .First(c=>c.Id==id);
            }
            return cliente;
        }
        public static void Actualizar(Clientes cli)
        {
            using (var contexto = new Model1Contexto())
            {
                var clienteDesdeBase=contexto.Clientes.First(c=>c.Id==cli.Id);
                clienteDesdeBase.Nombre=cli.Nombre;
                clienteDesdeBase.IdCompania=cli.IdCompania;
                // Aqui busca todos los objetos modificados o eliminados y los guarda en la base de datos
                contexto.SaveChanges(); 

            }
        }
        public static void Eliminar(int id)
        {
            using (var contexto = new Model1Contexto())
            {
                var clienteDesdeBase = contexto.Clientes.First(c => c.Id ==id);
                contexto.Clientes.Remove(clienteDesdeBase);
                contexto.SaveChanges();
            }
        }
    }
}
