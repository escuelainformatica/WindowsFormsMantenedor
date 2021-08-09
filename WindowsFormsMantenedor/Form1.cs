using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            dataGridView1.AutoGenerateColumns = false;
            RefrescarGrilla();

        }

        public void RefrescarGrilla()
        {
            List<Clientes> clientes = ClienteRepo.ListarTodo();
            List<ClienteDto> clienteDto
                = clientes // lista de clientes
                .Select(cli => new ClienteDto(cli))  // cli(un cliente) => transformar en un ClienteDto
                .ToList(); // devuelvo la lista de clientesdto
            dataGridView1.DataSource = clienteDto;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                // click en boton editar


                List<ClienteDto> clienteDto = (List<ClienteDto>)dataGridView1.DataSource;
                ClienteDto fila = clienteDto[e.RowIndex];
                Clientes cli = ClienteRepo.Obtener(fila.Id);
                FormEdicion formulario = new FormEdicion();
                ClientesVisual.MostrarFormulario(formulario, cli);
                formulario.clientes = cli;
                formulario.ShowDialog();
                RefrescarGrilla();
            }
            if(e.ColumnIndex==4)
            {
                // click en eliminar.
                List<ClienteDto> clienteDto = (List<ClienteDto>)dataGridView1.DataSource;
                ClienteDto fila = clienteDto[e.RowIndex];
                Clientes cli = ClienteRepo.Obtener(fila.Id);

                var confirmacion=MessageBox.Show("Quier eliminar este elemento?","Titulo",MessageBoxButtons.YesNo);

                if(confirmacion==DialogResult.Yes)
                {
                    ClienteRepo.Eliminar(cli.Id);
                    RefrescarGrilla();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelGrilla.Visible=false;
            panelInsertar.Visible=true;

            Clientes clienteVacio=new Clientes();
            ClientesVisual.MostrarFormularioInsertar(this,clienteVacio);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Clientes cli=ClientesVisual.ObtenerDelFormularioInsertar(this);
            ClienteRepo.Insertar(cli);
            panelGrilla.Visible = true;
            panelInsertar.Visible = false;
            RefrescarGrilla();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var resultadoArchivo=saveFileDialog1.ShowDialog();

            if(resultadoArchivo==DialogResult.Cancel)
            {
                return;
            }


            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            FileInfo newFile = new FileInfo(Application.UserAppDataPath+"\\template.xlsx");

            ExcelPackage ExcelPkg = new ExcelPackage(newFile);
            //ExcelPackage ExcelPkg = new ExcelPackage();
            //ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Sheet1");
            ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets["Hoja1"];

   

            //wsSheet1.Column(2).Width=32;

            //wsSheet1.Cells[1, 1].Value="Id";
            //wsSheet1.Cells[1, 2].Value = "Nombre";
            //wsSheet1.Cells[1, 3].Value = "Compañia";

            List<Clientes> clientes = ClienteRepo.ListarTodo();
            int fila=6;
            var tbl = wsSheet1.Tables["TablaClientes"];
            foreach (var cli in clientes)
            {
                wsSheet1.Cells[fila, 2].Value=cli.Id;
                wsSheet1.Cells[fila, 3].Value = cli.Nombre;
                wsSheet1.Cells[fila, 4].Value = cli.Companias.Compania;
                fila=fila+1;
                tbl.AddRow(1);
            }

            ExcelBarChart grafico = (ExcelBarChart)wsSheet1.Drawings["Grafico1"];
            grafico.Series[0].XSeries = wsSheet1.Cells[6, 2, 6+clientes.Count(), 4].FullAddress;
            grafico.Series[0].Series = wsSheet1.Cells[6, 2, 6+clientes.Count(), 4].FullAddress;

            wsSheet1.Protection.IsProtected = false;
            wsSheet1.Protection.AllowSelectLockedCells = false;
            ExcelPkg.SaveAs(new FileInfo(saveFileDialog1.FileName));


        }
    }
}
