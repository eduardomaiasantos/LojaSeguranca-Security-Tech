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
    public partial class FormAjuda : Form
    {
        public FormAjuda()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            // Cria novamente a tela do menu principal
            FormMenu menu = new FormMenu();

            // Mostra o menu principal
            menu.Show();

            // Esconde a tela de ajuda
            this.Hide();
        }
    }
}
