using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsMantenedor.ef;
using WindowsFormsMantenedor.repo;

namespace WindowsFormsMantenedor.visual
{
    class ClientesVisual
    {
        public static void MostrarFormulario(FormEdicion formulario,Clientes cli)
        {
            formulario.comboBoxCompania.DataSource=CompaniaRepo.ListarTodo();
            // para que funcione la siguiente linea, hay que agregar
            //  "static bool operator !=" en la clase Companias
            formulario.comboBoxCompania.SelectedItem=cli.Companias;
            formulario.labelId.Text = cli.Id.ToString();
            formulario.textBoxNombre.Text=cli.Nombre;
        }
        public static Clientes ObtenerDelFormulario(FormEdicion formulario)
        {
            Clientes cli=new Clientes();
            cli.Id=Convert.ToInt32(formulario.labelId.Text);
            cli.Nombre=formulario.textBoxNombre.Text;
            cli.IdCompania= ((Companias)formulario.comboBoxCompania.SelectedItem).Id;
            return cli;
        }
    }
}
