using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace reunioes
{
    public class CadastroBancoDados
    {

        public SqlConnection conexao()
        {
            string conec = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            SqlConnection cn = new SqlConnection(conec);

            return cn;
        }

        public SqlConnection abrirConexao()
        {
            SqlConnection cn = conexao();

            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void fecharConexao(SqlConnection cn)
        {
            try
            {
                cn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable executeQuery(string sql)
        {
            try
            {
                SqlCommand sqlComm = new SqlCommand(sql, abrirConexao());

                sqlComm.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(sqlComm);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Guid SqlCommandInsereEndereco(SqlConnection conexao, Endereco endereco)
        {
            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "INSERT INTO Endereco (nm_rua, nr_rua, nm_bairro, nm_estado, nm_cidade, nr_cep) " +
                "OUTPUT INSERTED.id_Endereco " +
                "VALUES (@nm_rua, @nr_rua, @nm_bairro, @nm_estado, @nm_cidade, @nr_cep)";
            SqlParameter nm_rua = new SqlParameter("@nm_rua", SqlDbType.Text, 200);
            SqlParameter nr_rua = new SqlParameter("@nr_rua", SqlDbType.Int, 0);
            SqlParameter nm_bairro = new SqlParameter("@nm_bairro", SqlDbType.Text, 200);
            SqlParameter nm_estado = new SqlParameter("@nm_estado", SqlDbType.Text, 200);
            SqlParameter nm_cidade = new SqlParameter("@nm_cidade", SqlDbType.Text, 200);
            SqlParameter nr_cep = new SqlParameter("@nr_cep", SqlDbType.Int, 0);

            nm_rua.Value = endereco.nm_rua;
            nr_rua.Value = endereco.nr_rua;
            nm_bairro.Value = endereco.nm_bairro;
            nm_estado.Value = endereco.nm_estado;
            nm_cidade.Value = endereco.nm_cidade;
            nr_cep.Value = endereco.nr_cep;
            comando.Parameters.Add(nm_rua);
            comando.Parameters.Add(nr_rua);
            comando.Parameters.Add(nm_bairro);
            comando.Parameters.Add(nm_estado);
            comando.Parameters.Add(nm_cidade);
            comando.Parameters.Add(nr_cep);

            Guid id_Endereco = (Guid)comando.ExecuteScalar();

            return id_Endereco;

        }

        public void SqlCommandAtualizaEndereco(SqlConnection conexao, Endereco endereco)
        {
            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "UPDATE Endereco SET nm_rua=@nm_rua, nr_rua=@nr_rua, nm_bairro=@nm_bairro, nm_estado=@nm_estado, nm_cidade=@nm_cidade, nr_cep=@nr_cep " +
                "WHERE id_endereco = @id_endereco";
            SqlParameter nm_rua = new SqlParameter("@nm_rua", SqlDbType.Text, 200);
            SqlParameter nr_rua = new SqlParameter("@nr_rua", SqlDbType.Int, 0);
            SqlParameter nm_bairro = new SqlParameter("@nm_bairro", SqlDbType.Text, 200);
            SqlParameter nm_estado = new SqlParameter("@nm_estado", SqlDbType.Text, 200);
            SqlParameter nm_cidade = new SqlParameter("@nm_cidade", SqlDbType.Text, 200);
            SqlParameter nr_cep = new SqlParameter("@nr_cep", SqlDbType.Int, 0);
            SqlParameter id_endereco = new SqlParameter("@id_endereco", SqlDbType.UniqueIdentifier, 0);

            nm_rua.Value = endereco.nm_rua;
            nr_rua.Value = endereco.nr_rua;
            nm_bairro.Value = endereco.nm_bairro;
            nm_estado.Value = endereco.nm_estado;
            nm_cidade.Value = endereco.nm_cidade;
            nr_cep.Value = endereco.nr_cep;
            id_endereco.Value = endereco.id_endereco;

            comando.Parameters.Add(nm_rua);
            comando.Parameters.Add(nr_rua);
            comando.Parameters.Add(nm_bairro);
            comando.Parameters.Add(nm_estado);
            comando.Parameters.Add(nm_cidade);
            comando.Parameters.Add(nr_cep);
            comando.Parameters.Add(id_endereco);

            comando.Prepare();
            comando.ExecuteNonQuery();

        }
     
    }
}
