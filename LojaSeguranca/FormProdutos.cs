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
    public partial class FormProdutos : Form
    {
        int idProduto = 0;
        public FormProdutos()
        {
            InitializeComponent();
        }

        private void CarregarProdutos()
        {
            Conexao conexao = new Conexao();

            string sql = "SELECT * FROM Produtos";

            SqlDataAdapter da = new SqlDataAdapter(sql, conexao.AbrirConexao());

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvProdutos.DataSource = dt;

            conexao.FecharConexao();
        }

        private void FormProdutos_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            // Cria novamente a tela do menu
            FormMenu menu = new FormMenu();

            // Mostra o menu
            menu.Show();

            // Esconde a tela de produtos
            this.Hide();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" ||
    txtCategoria.Text == "" ||
    txtPreco.Text == "" ||
    txtQuantidade.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            Conexao conexao = new Conexao();

            string sql = @"INSERT INTO Produtos
                  (Nome, Categoria, Preco, Quantidade)
                  VALUES
                  (@nome, @categoria, @preco, @quantidade)";

            SqlCommand cmd = new SqlCommand(sql, conexao.AbrirConexao());

            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@categoria", txtCategoria.Text);
            cmd.Parameters.AddWithValue("@preco", decimal.Parse(txtPreco.Text));
            cmd.Parameters.AddWithValue("@quantidade", int.Parse(txtQuantidade.Text));

            cmd.ExecuteNonQuery();

            MessageBox.Show("Produto cadastrado com sucesso!");

            txtNome.Clear();
            txtCategoria.Clear();
            txtPreco.Clear();
            txtQuantidade.Clear();

            txtNome.Focus();

            CarregarProdutos();

            conexao.FecharConexao();
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show(
        "Deseja realmente excluir este produto?",
        "Confirmação",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (resposta == DialogResult.No)
            {
                return;
            }


            if (dgvProdutos.CurrentRow != null)
            {
                int id = Convert.ToInt32(
                    dgvProdutos.CurrentRow.Cells["Id"].Value);

                Conexao conexao = new Conexao();

                string sql = "DELETE FROM Produtos WHERE Id=@id";

                SqlCommand cmd =
                    new SqlCommand(sql, conexao.AbrirConexao());

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Produto excluído!");

                conexao.FecharConexao();

                CarregarProdutos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(
        dgvProdutos.CurrentRow.Cells["Id"].Value);

            Conexao conexao = new Conexao();

            string sql = @"UPDATE Produtos
                   SET Nome=@nome,
                       Categoria=@categoria,
                       Preco=@preco,
                       Quantidade=@quantidade
                   WHERE Id=@id";

            SqlCommand cmd =
                new SqlCommand(sql, conexao.AbrirConexao());

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@categoria", txtCategoria.Text);
            cmd.Parameters.AddWithValue("@preco", decimal.Parse(txtPreco.Text));
            cmd.Parameters.AddWithValue("@quantidade", int.Parse(txtQuantidade.Text));

            cmd.ExecuteNonQuery();

            MessageBox.Show("Produto atualizado!");

            txtNome.Clear();
            txtCategoria.Clear();
            txtPreco.Clear();
            txtQuantidade.Clear();

            txtNome.Focus();


            conexao.FecharConexao();

            CarregarProdutos();
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvProdutos.CurrentRow != null)
            {
                idProduto = Convert.ToInt32(
    dgvProdutos.CurrentRow.Cells["Id"].Value);

                txtNome.Text =
                    dgvProdutos.CurrentRow.Cells["Nome"].Value.ToString();

                txtCategoria.Text =
                    dgvProdutos.CurrentRow.Cells["Categoria"].Value.ToString();

                txtPreco.Text =
                    dgvProdutos.CurrentRow.Cells["Preco"].Value.ToString();

                txtQuantidade.Text =
                    dgvProdutos.CurrentRow.Cells["Quantidade"].Value.ToString();
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();

            string sql =
                "SELECT * FROM Produtos WHERE Nome LIKE @nome";

            SqlDataAdapter da =
                new SqlDataAdapter(sql, conexao.AbrirConexao());

            da.SelectCommand.Parameters.AddWithValue(
                "@nome",
                "%" + txtPesquisarp.Text + "%");

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvProdutos.DataSource = dt;

            conexao.FecharConexao();
        }

        private void txtPesquisarp_TextChanged(object sender, EventArgs e)
        {
            if (txtPesquisarp.Text == "")
            {
                CarregarProdutos();
            }
        }
    }
}
