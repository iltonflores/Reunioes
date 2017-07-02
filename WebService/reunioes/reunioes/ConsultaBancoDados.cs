using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace reunioes
{
    public class ConsultaBancoDados
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

        public List<Endereco> SqlCommandConsultaEndereco(SqlConnection conexao, Guid id_endereco, String nm_cidade, int nr_cep, String nm_estado)
        {
            SqlDataReader reader = null;

            List<Endereco> enderecos = new List<Endereco>();
            try
            {

                SqlCommand comando = new SqlCommand(null, conexao);

                comando.CommandText = "SELECT * FROM Endereco";

                comando = SqlAddParametro(conexao, comando, nm_cidade, "nm_cidade");
                comando = SqlAddParametro(conexao, comando, nm_estado, "nm_estado");
                comando = SqlAddParametro(conexao, comando, nr_cep, "nr_cep");
                comando = SqlAddParametro(conexao, comando, id_endereco, "id_endereco");

                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    Endereco endereco = new Endereco();

                    endereco.id_endereco = reader.GetGuid(reader.GetOrdinal("id_endereco"));
                    endereco.nm_rua = reader["nm_rua"].ToString();
                    endereco.nr_rua = Convert.ToInt32(reader["nr_rua"].ToString());
                    endereco.nm_bairro = reader["nm_bairro"].ToString();
                    endereco.nm_estado = reader["nm_estado"].ToString();
                    endereco.nm_cidade = reader["nm_cidade"].ToString();
                    endereco.nr_cep = Convert.ToInt32(reader["nr_cep"].ToString());
                    enderecos.Add(endereco);
                }

                return enderecos;

            }
            catch (Exception e)
            {
                Endereco endereco = new Endereco();
                endereco.id_endereco = new Guid();
                endereco.nm_cidade = "Ocorreu o erro:" + e.Message;
                enderecos.Add(endereco);

                return enderecos;
            }
            finally
            {
                // close reader
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public List<Filial> SqlCommandConsultaFilial(SqlConnection conexao, Guid id_filial, Int64 nr_cnpj)
        {
            SqlDataReader reader = null;

            List<Filial> filiais = new List<Filial>();
            try
            {

                SqlCommand comando = new SqlCommand(null, conexao);

                comando.CommandText = "SELECT * FROM Filial";

                comando = SqlAddParametro(conexao, comando, id_filial, "id_filial");
                comando = SqlAddParametro(conexao, comando, nr_cnpj, "nr_cnpj");

                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    Filial filial = new Filial();

                    filial.id_filial = reader.GetGuid(reader.GetOrdinal("id_filial"));
                    filial.nm_filial = reader["nm_filial"].ToString();
                    filial.nr_cnpj = Convert.ToInt64(reader["nr_cnpj"].ToString());
                    filial.id_endereco = reader.GetGuid(reader.GetOrdinal("id_endereco"));
                    filiais.Add(filial);
                }

                return filiais;

            }
            catch (Exception e)
            {
                Filial filial = new Filial();
                filial.id_filial = new Guid();
                filial.nm_filial = "Ocorreu o erro:" + e.Message;
                filiais.Add(filial);

                return filiais;
            }
            finally
            {
                // close reader
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public List<Sala> SqlCommandConsultaSala(SqlConnection conexao, Guid id_sala, String nm_sala)
        {
            SqlDataReader reader = null;

            List<Sala> salas = new List<Sala>();
            try
            {

                SqlCommand comando = new SqlCommand(null, conexao);

                comando.CommandText = "SELECT * FROM Sala";

                comando = SqlAddParametro(conexao, comando, id_sala, "id_sala");
                comando = SqlAddParametro(conexao, comando, nm_sala, "nm_sala");

                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    Sala sala = new Sala();

                    sala.id_sala = reader.GetGuid(reader.GetOrdinal("id_sala"));
                    sala.nm_sala = reader["nm_sala"].ToString();
                    salas.Add(sala);
                }

                return salas;

            }
            catch (Exception e)
            {
                Sala sala = new Sala();
                sala.id_sala = new Guid();
                sala.nm_sala = "Ocorreu o erro:" + e.Message;
                salas.Add(sala);

                return salas;
            }
            finally
            {
                // close reader
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public List<Responsavel> SqlCommandConsultaResponsavel(SqlConnection conexao, Guid id_responsavel, Int64 nr_cpf)
        {
            SqlDataReader reader = null;

            List<Responsavel> responsaveis = new List<Responsavel>();
            try
            {

                SqlCommand comando = new SqlCommand(null, conexao);

                comando.CommandText = "SELECT * FROM Responsavel";

                comando = SqlAddParametro(conexao, comando, id_responsavel, "id_responsavel");
                comando = SqlAddParametro(conexao, comando, nr_cpf, "nr_cpf");

                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    Responsavel responsavel = new Responsavel();

                    responsavel.id_responsavel = reader.GetGuid(reader.GetOrdinal("id_responsavel"));
                    responsavel.nm_responsavel = reader["nm_responsavel"].ToString();
                    responsavel.nr_telefone = Convert.ToInt64(reader["nr_telefone"].ToString());
                    responsavel.nr_cpf = Convert.ToInt64(reader["nr_cpf"].ToString());
                    responsaveis.Add(responsavel);
                }

                return responsaveis;

            }
            catch (Exception e)
            {
                Responsavel responsavel = new Responsavel();
                responsavel.id_responsavel = new Guid();
                responsavel.nm_responsavel = "Ocorreu o erro:" + e.Message;
                responsaveis.Add(responsavel);

                return responsaveis;
            }
            finally
            {
                // close reader
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public List<Reserva> SqlCommandConsultaReserva(SqlConnection conexao, Guid id_reserva, DateTime dt_inicio, DateTime dt_fim, Guid id_sala, Guid id_filial)
        {
            SqlDataReader reader = null;

            List<Reserva> reservas = new List<Reserva>();
            try
            {

                SqlCommand comando = new SqlCommand(null, conexao);

                comando.CommandText = "SELECT * FROM Reserva";

                comando = SqlAddParametro(conexao, comando, id_reserva, "id_reserva");
                comando = SqlAddParametro(conexao, comando, dt_inicio, "dt_inicio");
                comando = SqlAddParametro(conexao, comando, dt_fim, "dt_fim");
                comando = SqlAddParametro(conexao, comando, id_sala, "id_sala");
                comando = SqlAddParametro(conexao, comando, id_filial, "id_filial");

                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    Reserva reserva = new Reserva();

                    reserva.id_reserva = reader.GetGuid(reader.GetOrdinal("id_reserva"));
                    reserva.id_filial = reader.GetGuid(reader.GetOrdinal("id_filial"));
                    reserva.id_sala = reader.GetGuid(reader.GetOrdinal("id_sala"));
                    reserva.dt_inicio=Convert.ToDateTime(reader["dt_inicio"].ToString());
                    reserva.dt_fim=Convert.ToDateTime(reader["dt_fim"].ToString());
                    reserva.id_responsavel = reader.GetGuid(reader.GetOrdinal("id_responsavel"));
                    reserva.dv_cafe = Convert.ToBoolean(reader["dv_cafe"].ToString()); 
                    reserva.qt_cafe = Convert.ToInt16(reader["qt_cafe"].ToString());
                    reserva.nm_descricao = reader["nm_descricao"].ToString();
                    reservas.Add(reserva);
                }

                return reservas;

            }
            catch (Exception e)
            {
                Reserva reserva = new Reserva();
                reserva.id_reserva = new Guid();
                reserva.nm_descricao = "Ocorreu o erro:" + e.Message;
                reservas.Add(reserva);

                return reservas;
            }
            finally
            {
                // close reader
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public List<Reserva> SqlCommandConsultaReservaIntervalo(SqlConnection conexao, Guid id_reserva, DateTime dt_inicio, DateTime dt_fim, Guid id_sala, Guid id_filial)
        {
            SqlDataReader reader = null;

            List<Reserva> reservas = new List<Reserva>();
            try
            {

                SqlCommand comando = new SqlCommand(null, conexao);

                comando.CommandText = "SELECT * FROM Reserva "+
                                      "WHERE (@dt_inicio between dt_inicio and dt_fim OR " +
                                       "@dt_fim between dt_inicio and dt_fim OR " +
                                       "(@dt_inicio < dt_inicio AND " +
                                       "@dt_fim > dt_fim))";

                SqlParameter parametro_inicio = new SqlParameter();
                parametro_inicio.ParameterName = "@dt_inicio";
                parametro_inicio.Value = dt_inicio;

                comando.Parameters.Add(parametro_inicio);

                SqlParameter parametro_fim = new SqlParameter();
                parametro_fim.ParameterName = "@dt_fim";
                parametro_fim.Value = dt_fim;

                comando.Parameters.Add(parametro_fim);

                comando = SqlAddParametro(conexao, comando, id_reserva, "id_reserva");
                comando = SqlAddParametro(conexao, comando, id_sala, "id_sala");
                comando = SqlAddParametro(conexao, comando, id_filial, "id_filial");

                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    Reserva reserva = new Reserva();

                    reserva.id_reserva = reader.GetGuid(reader.GetOrdinal("id_reserva"));
                    reserva.id_filial = reader.GetGuid(reader.GetOrdinal("id_filial"));
                    reserva.id_sala = reader.GetGuid(reader.GetOrdinal("id_sala"));
                    reserva.dt_inicio = Convert.ToDateTime(reader["dt_inicio"].ToString());
                    reserva.dt_fim = Convert.ToDateTime(reader["dt_fim"].ToString());
                    reserva.id_responsavel = reader.GetGuid(reader.GetOrdinal("id_responsavel"));
                    reserva.dv_cafe = Convert.ToBoolean(reader["dv_cafe"].ToString());
                    reserva.qt_cafe = Convert.ToInt16(reader["qt_cafe"].ToString());
                    reserva.nm_descricao = reader["nm_descricao"].ToString();
                    reservas.Add(reserva);
                }

                return reservas;

            }
            catch (Exception e)
            {
                Reserva reserva = new Reserva();
                reserva.id_reserva = new Guid();
                reserva.nm_descricao = "Ocorreu o erro:" + e.Message;
                reservas.Add(reserva);

                return reservas;
            }
            finally
            {
                // close reader
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public List<ReservaTextoLista> SqlCommandConsultaReservaTextoLista(SqlConnection conexao, Guid id_reserva, DateTime dt_inicio, DateTime dt_fim, Guid id_sala, Guid id_filial)
        {
            SqlDataReader reader = null;

            List<ReservaTextoLista> reservas = new List<ReservaTextoLista>();
            try
            {

                SqlCommand comando = new SqlCommand(null, conexao);

                comando.CommandText = "SELECT r.*, s.nm_sala, f.nm_filial, rp.nm_responsavel FROM Reserva r "+
                                      "INNER JOIN sala s ON s.id_sala = r.id_sala "+
                                      "INNER JOIN filial f ON f.id_filial = r.id_filial "+
                                      "INNER JOIN Responsavel rp ON rp.id_responsavel = r.id_responsavel";

                comando = SqlAddParametro(conexao, comando, id_reserva, "id_reserva");
                comando = SqlAddParametro(conexao, comando, dt_inicio, "dt_inicio");
                comando = SqlAddParametro(conexao, comando, dt_fim, "dt_fim");
                comando = SqlAddParametro(conexao, comando, id_sala, "id_sala");
                comando = SqlAddParametro(conexao, comando, id_filial, "id_filial");

                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    ReservaTextoLista reserva = new ReservaTextoLista();

                    reserva.id_reserva = reader.GetGuid(reader.GetOrdinal("id_reserva"));
                    reserva.id_filial = reader.GetGuid(reader.GetOrdinal("id_filial"));
                    reserva.id_sala = reader.GetGuid(reader.GetOrdinal("id_sala"));
                    reserva.dt_inicio = Convert.ToDateTime(reader["dt_inicio"].ToString());
                    reserva.dt_fim = Convert.ToDateTime(reader["dt_fim"].ToString());
                    reserva.id_responsavel = reader.GetGuid(reader.GetOrdinal("id_responsavel"));
                    reserva.dv_cafe = Convert.ToBoolean(reader["dv_cafe"].ToString());
                    reserva.qt_cafe = Convert.ToInt16(reader["qt_cafe"].ToString());
                    reserva.nm_descricao = reader["nm_descricao"].ToString();
                    reserva.nm_sala = reader["nm_sala"].ToString();
                    reserva.nm_filial = reader["nm_filial"].ToString();
                    reserva.nm_responsavel = reader["nm_responsavel"].ToString();
                    reservas.Add(reserva);
                }

                return reservas;

            }
            catch (Exception e)
            {
                ReservaTextoLista reserva = new ReservaTextoLista();
                reserva.id_reserva = new Guid();
                reserva.nm_descricao = "Ocorreu o erro:" + e.Message;
                reservas.Add(reserva);

                return reservas;
            }
            finally
            {
                // close reader
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
