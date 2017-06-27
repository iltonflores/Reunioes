using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace reunioes
{
    public class RemoveBancoDados
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

        public SqlCommand SqlAddParametro(SqlConnection conexao, SqlCommand comando, Guid parametroid, String nome)
        {
            if (!parametroid.ToString().Equals("00000000-0000-0000-0000-000000000000"))
            {
                String nome_variavel = nome;
                if (nome.IndexOf(".") >= 0)
                {
                    nome_variavel = nome.Substring(nome.IndexOf(".") + 1, nome.Length - nome.IndexOf(".") - 1);
                }

                int where = comando.CommandText.IndexOf("WHERE");

                if (where == -1)
                {
                    comando.CommandText = comando.CommandText + " WHERE " + nome + " = @" + nome_variavel;
                }
                else
                {
                    comando.CommandText = comando.CommandText + " AND " + nome + " = @" + nome_variavel;
                }

                SqlParameter parametro = new SqlParameter("@" + nome_variavel, SqlDbType.UniqueIdentifier, 0);
                parametro.Value = parametroid;

                comando.Parameters.Add(parametro);
            }
            return comando;
        }

        public SqlCommand SqlAddParametro(SqlConnection conexao, SqlCommand comando, DateTime parametrodata, String nome)
        {

            if (DateTime.MinValue != parametrodata)
            {
                int where = comando.CommandText.IndexOf("WHERE");

                if (where == -1)
                {
                    comando.CommandText = comando.CommandText + " WHERE " + nome + " = @" + nome;
                }
                else
                {
                    comando.CommandText = comando.CommandText + " AND " + nome + " = @" + nome;
                }

                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@" + nome;
                parametro.Value = parametrodata;

                comando.Parameters.Add(parametro);
            }
            return comando;
        }

        public SqlCommand SqlAddParametro(SqlConnection conexao, SqlCommand comando, Int64 parametroint64, String nome)
        {

            if (parametroint64 != 0)
            {
                int where = comando.CommandText.IndexOf("WHERE");

                if (where == -1)
                {
                    comando.CommandText = comando.CommandText + " WHERE " + nome + " = @" + nome;
                }
                else
                {
                    comando.CommandText = comando.CommandText + " AND " + nome + " = @" + nome;
                }

                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@" + nome;
                parametro.Value = parametroint64;

                comando.Parameters.Add(parametro);
            }
            return comando;
        }

        public SqlCommand SqlAddParametro(SqlConnection conexao, SqlCommand comando, String parametrostr, String nome)
        {

            if (!string.IsNullOrEmpty(parametrostr))
            {
                int where = comando.CommandText.IndexOf("WHERE");

                if (where == -1)
                {
                    comando.CommandText = comando.CommandText + " WHERE " + nome + " like '%'+ @" + nome + "+'%'";
                }
                else
                {
                    comando.CommandText = comando.CommandText + " AND " + nome + " like '%'+ @" + nome + "+'%'";
                }

                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@" + nome;
                parametro.Value = parametrostr;

                comando.Parameters.Add(parametro);
            }
            return comando;
        }

        public void RemoveEndereco(SqlConnection conexao, Guid id_endereco, Guid id_filial)
        {

            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "DELETE ende " +
                "FROM Endereco ende " +
                "LEFT JOIN Filial fil ON fil.id_endereco = ende.id_endereco ";

            comando = SqlAddParametro(conexao, comando, id_endereco, "ende.id_endereco");
            comando = SqlAddParametro(conexao, comando, id_filial, "fil.id_filial");

            comando.Prepare();
            comando.ExecuteNonQuery();
        }

        public void RemoveFiliais(SqlConnection conexao, Guid id_filial)
        {
            RemoveReserva(conexao, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), id_filial);

            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "DELETE fil " +
                "FROM Filial fil ";

            comando = SqlAddParametro(conexao, comando, id_filial, "fil.id_filial");

            comando.Prepare();
            comando.ExecuteNonQuery();
        }

        public void RemoveSala(SqlConnection conexao, Guid id_sala)
        {
            RemoveReserva(conexao, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), id_sala, new Guid("00000000-0000-0000-0000-000000000000"));

            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "DELETE sal " +
                "FROM Sala sal ";

            comando = SqlAddParametro(conexao, comando, id_sala, "sal.id_sala");

            comando.Prepare();
            comando.ExecuteNonQuery();
        }

        public void RemoveResponsavel(SqlConnection conexao, Guid id_responsavel)
        {
            RemoveReserva(conexao, new Guid("00000000-0000-0000-0000-000000000000"), id_responsavel, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"));

            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "DELETE res " +
                "FROM Responsavel res ";

            comando = SqlAddParametro(conexao, comando, id_responsavel, "res.id_responsavel");

            comando.Prepare();
            comando.ExecuteNonQuery();
        }

        public void RemoveReserva(SqlConnection conexao, Guid id_reserva, Guid id_responsavel, Guid id_sala, Guid id_filial)
        {

            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "DELETE res " +
                "FROM Reserva res ";

            comando = SqlAddParametro(conexao, comando, id_reserva, "res.id_reserva");
            comando = SqlAddParametro(conexao, comando, id_responsavel, "res.id_responsavel");
            comando = SqlAddParametro(conexao, comando, id_sala, "res.id_sala");
            comando = SqlAddParametro(conexao, comando, id_filial, "res.id_filial");

            comando.Prepare();
            comando.ExecuteNonQuery();
        }
       
    }
}