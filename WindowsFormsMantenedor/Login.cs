using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsMantenedor.repo;

namespace WindowsFormsMantenedor
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var usuario = UsuarioRepo.ValidarUsuario(userName, "AUTOLOGIN");
            if(usuario==null)
            {
                return;
            }
            // auto login
            var form1 = new Form1(usuario);

            this.Hide();
            form1.ShowDialog();
            this.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            var usuario=UsuarioRepo.ValidarUsuario(textBox1.Text,textBox2.Text);
            if(usuario==null)
            {
                MessageBox.Show("Usuario o clave incorrecta");
                return;
            }
            

            var form1=new Form1(usuario);

            this.Hide();
            form1.ShowDialog();
            this.Close();            
        }
    }
}
