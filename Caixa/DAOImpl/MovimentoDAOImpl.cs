using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CaixaLibrary
{
    class MovimentoDAOImpl
    {
        private SqlConnection connection;

        public void inserirMovimento (DateTime data, String tipoMovimento, String referencia,
            String descricao, String valor)
        {
            connection = Conexao.obterConexao();

            String sql = "INSERT INTO movimento VALUES (@data_inclusao, @tipo_movimento, " +
            "@referencia, @descricao, @valor, @encerrado)";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.Parameters.Add("@data_inclusao", SqlDbType.Date);
            sqlCommand.Parameters.Add("@tipo_movimento", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@referencia", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@descricao", SqlDbType.VarChar);
            sqlCommand.Parameters.Add("@valor", SqlDbType.Real);
            sqlCommand.Parameters.Add("@encerrado", SqlDbType.Bit);

            sqlCommand.Parameters["@data_inclusao"].Value = data.Date;
            sqlCommand.Parameters["@tipo_movimento"].Value = tipoMovimento;
            sqlCommand.Parameters["@referencia"].Value = referencia;
            sqlCommand.Parameters["@descricao"].Value = descricao;
            sqlCommand.Parameters["@valor"].Value = valor;
            sqlCommand.Parameters["@encerrado"].Value = 0;

            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
        }

    }
}
