using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsMantenedor.ef;
using WindowsFormsMantenedor.repo;
using WindowsFormsMantenedor.visual;

namespace WindowsFormsMantenedor
{
    public partial class FormEdicion : Form
    {
        public Clientes clientes { set; get;}


        public FormEdicion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cli=ClientesVisual.ObtenerDelFormulario(this);
            ClienteRepo.Actualizar(cli);
            this.Close();
        }
    }
}
