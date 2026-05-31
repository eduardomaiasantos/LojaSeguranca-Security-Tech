using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaSeguranca
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria a tela de produtos
            FormProdutos produtos = new FormProdutos();

            // Mostra a tela
            produtos.Show();

            // Esconde o menu principal
            this.Hide();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria a tela de ajuda
            FormAjuda ajuda = new FormAjuda();

            // Mostra a tela de ajuda
            ajuda.Show();

            // Esconde o menu principal
            this.Hide();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes clientes = new FormClientes();

            clientes.Show();

            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
