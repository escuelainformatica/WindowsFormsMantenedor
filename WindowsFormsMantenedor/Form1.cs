using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsMantenedor.dto;
using WindowsFormsMantenedor.ef;
using WindowsFormsMantenedor.repo;
using WindowsFormsMantenedor.visual;

namespace WindowsFormsMantenedor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns=false;

            List<Clientes> clientes=ClienteRepo.ListarTodo();
            List<ClienteDto> clienteDto
                =clientes // lista de clientes
                .Select(cli=>new ClienteDto(cli))  // cli(un cliente) => transformar en un ClienteDto
                .ToList(); // devuelvo la lista de clientesdto


            dataGridView1.DataSource= clienteDto;

        


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<ClienteDto> clienteDto=(List<ClienteDto>) dataGridView1.DataSource;
            ClienteDto fila = clienteDto[e.RowIndex];
            Clientes cli=ClienteRepo.Obtener(fila.Id);
            FormEdicion formulario=new FormEdicion();
            ClientesVisual.MostrarFormulario(formulario,cli);
            formulario.clientes=cli;
            formulario.ShowDialog();

            List<Clientes> clientes = ClienteRepo.ListarTodo();
            List<ClienteDto> clientesDto
                = clientes // lista de clientes
                .Select(c => new ClienteDto(c))  // cli(un cliente) => transformar en un ClienteDto
                .ToList(); // devuelvo la lista de clientesdto


            dataGridView1.DataSource = clientesDto;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Companias comp1=new Companias();
            comp1.Id = 2;
            Companias comp2 = new Companias();
            comp2.Id = 2;

            if(comp1==comp2)
            {
                MessageBox.Show("son iguales");
            }


        }
    }
}
