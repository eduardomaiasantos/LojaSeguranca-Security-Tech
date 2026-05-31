using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaSeguranca
{
    public partial class FormClientes : Form
    {

        private int idCliente = 0;
        public FormClientes()
        {
            InitializeComponent();

            CarregarClientes();

            dgvClientesc.CellClick += dgvClientesc_CellClick;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (txtNomec.Text == "" ||
    txtTelefonec.Text == "" ||
    txtEmailc.Text == "" ||
    txtEnderecoc.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            Conexao conexao = new Conexao();

            string sql = @"INSERT INTO Clientes
              (Nome, Telefone, Email, Endereco)
              VALUES
              (@nome, @telefone, @email, @endereco)";

            SqlCommand cmd = new SqlCommand(sql, conexao.AbrirConexao());

            cmd.Parameters.AddWithValue("@nome", txtNomec.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTelefonec.Text);
            cmd.Parameters.AddWithValue("@email", txtEmailc.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEnderecoc.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Cliente cadastrado com sucesso!");

            txtNomec.Clear();
            txtTelefonec.Clear();
            txtEmailc.Clear();
            txtEnderecoc.Clear();

            txtNomec.Focus();

            conexao.FecharConexao();

            CarregarClientes();
        }

        public void CarregarClientes()
        {
            Conexao conexao = new Conexao();

            string sql = "SELECT * FROM Clientes";

            SqlDataAdapter da =
                new SqlDataAdapter(sql, conexao.AbrirConexao());

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvClientesc.DataSource = dt;

            conexao.FecharConexao();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {

        }


        private void dgvClientesc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientesc.CurrentRow != null)
            {
                idCliente = Convert.ToInt32(
            dgvClientesc.CurrentRow.Cells["Id"].Value);

                txtNomec.Text =
                    dgvClientesc.CurrentRow.Cells["Nome"].Value.ToString();

                txtTelefonec.Text =
                    dgvClientesc.CurrentRow.Cells["Telefone"].Value.ToString();

                txtEmailc.Text =
                    dgvClientesc.CurrentRow.Cells["Email"].Value.ToString();

                txtEnderecoc.Text =
                    dgvClientesc.CurrentRow.Cells["Endereco"].Value.ToString();
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idCliente == 0)
            {
                MessageBox.Show("Selecione um cliente!");
                return;
            }

            Conexao conexao = new Conexao();

            string sql = @"UPDATE Clientes
               SET Nome=@nome,
                   Telefone=@telefone,
                   Email=@email,
                   Endereco=@endereco
               WHERE Id=@id";

            SqlCommand cmd =
                new SqlCommand(sql, conexao.AbrirConexao());

            cmd.Parameters.AddWithValue("@id", idCliente);
            cmd.Parameters.AddWithValue("@nome", txtNomec.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTelefonec.Text);
            cmd.Parameters.AddWithValue("@email", txtEmailc.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEnderecoc.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Cliente atualizado!");

            conexao.FecharConexao();

            CarregarClientes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idCliente == 0)
            {
                MessageBox.Show("Selecione um cliente!");
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir este cliente?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                Conexao conexao = new Conexao();

                string sql = "DELETE FROM Clientes WHERE Id=@id";

                SqlCommand cmd =
                    new SqlCommand(sql, conexao.AbrirConexao());

                cmd.Parameters.AddWithValue("@id", idCliente);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cliente excluído!");

                conexao.FecharConexao();

                txtNomec.Clear();
                txtTelefonec.Clear();
                txtEmailc.Clear();
                txtEnderecoc.Clear();

                idCliente = 0;

                CarregarClientes();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();

            menu.Show();

            this.Hide();
        }
    }
}
     


