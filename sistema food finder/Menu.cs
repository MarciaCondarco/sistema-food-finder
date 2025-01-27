using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_food_finder
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonCompras_Click(object sender, EventArgs e)
        {
            Compras form = new Compras();
            form.ShowDialog();
        }

        private void buttonPesquisa_Click(object sender, EventArgs e)
        {
            Pesquisa form = new Pesquisa();
            form.ShowDialog();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }
    }
}
