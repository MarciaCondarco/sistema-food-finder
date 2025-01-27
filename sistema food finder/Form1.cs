using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_food_finder
{
    public partial class Form1 : Form
    {
        private string usuarioCorreto = "admin";
        private string senhaCorreta = "123456";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuario.Text;
            string senha = textBoxSenha.Text;
            if (usuario == usuarioCorreto && senha == senhaCorreta)
            {
                labelVerificação.Text = "Login bem-sucedido";
                labelVerificação.ForeColor = Color.Green;
                Menu form = new Menu();
                form.ShowDialog();
               
            }
            else
            {
                labelVerificação.Text = "Usuario ou senha Invalida";
                labelVerificação.ForeColor = Color.Red;
                textBoxUsuario.Text = "";
                textBoxSenha.Text = "";
                textBoxUsuario.Focus();
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            CadUsuario form = new CadUsuario();
            form.ShowDialog();
        }
    }
}
