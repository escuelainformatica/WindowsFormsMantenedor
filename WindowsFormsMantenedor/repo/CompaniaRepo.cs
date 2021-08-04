using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsMantenedor.ef;

namespace WindowsFormsMantenedor.repo
{
    class CompaniaRepo
    {
        public static List<Companias> ListarTodo()
        {
            var listado = new List<Companias>();
            using (var contexto = new Model1Contexto())
            {
                listado = contexto
                     .Companias
                     .ToList();
            }

            return listado;
        }
    }
}
