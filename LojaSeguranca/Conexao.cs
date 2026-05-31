using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSeguranca
{
    public class Conexao
    {
        // Cria a conexão com o SQL Server
        SqlConnection conn = new SqlConnection(
            @"Data Source=.\SQLEXPRESS;
              Initial Catalog=LojaSeguranca;
              Integrated Security=True");

        // Método para abrir conexão
        public SqlConnection AbrirConexao()
        {
            // Verifica se a conexão está fechada
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                // Abre a conexão
                conn.Open();
            }

            // Retorna a conexão aberta
            return conn;
        }

        // Método para fechar conexão
        public void FecharConexao()
        {
            // Verifica se a conexão está aberta
            if (conn.State == System.Data.ConnectionState.Open)
            {
                // Fecha a conexão
                conn.Close();
            }
        }
    }
}