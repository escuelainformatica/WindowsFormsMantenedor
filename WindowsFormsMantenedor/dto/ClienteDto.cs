using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsMantenedor.ef;

// data transfer object.
// es una clase que se usa para transformar datos y poder transportarlos.
// DTO se asume que es de solo lectura.

namespace WindowsFormsMantenedor.dto
{
    class ClienteDto
    {
        public int Id { set; get;}
        public string Nombre { set; get;}
        public string NombreCompania { set; get;}

        public ClienteDto(Clientes cli)
        {
            Id = cli.Id;
            Nombre = cli.Nombre;
            NombreCompania = cli.Companias.Compania;
        }
    }
}
