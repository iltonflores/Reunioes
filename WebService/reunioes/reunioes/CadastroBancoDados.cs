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


        public Guid SqlCommandInsereFilial(SqlConnection conexao, Filial filial)
        {
            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "INSERT INTO Filial (nm_filial, nr_cnpj, id_endereco) " +
                "OUTPUT INSERTED.id_filial " +
                "VALUES (@nm_filial, @nr_cnpj, @id_endereco)";
            SqlParameter nm_filial = new SqlParameter("@nm_filial", SqlDbType.Text, 200);
            SqlParameter nr_cnpj = new SqlParameter("@nr_cnpj", SqlDbType.BigInt, 0);
            SqlParameter id_endereco = new SqlParameter("@id_endereco", SqlDbType.UniqueIdentifier, 0);

            nm_filial.Value = filial.nm_filial;
            nr_cnpj.Value = filial.nr_cnpj;
            id_endereco.Value = filial.id_endereco;
            comando.Parameters.Add(nm_filial);
            comando.Parameters.Add(nr_cnpj);
            comando.Parameters.Add(id_endereco);

            Guid id_filial = (Guid)comando.ExecuteScalar();

            return id_filial;

        }

        public void SqlCommandAtualizaFilial(SqlConnection conexao, Filial filial)
        {
            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "UPDATE Filial SET nm_filial=@nm_filial, nr_cnpj=@nr_cnpj, id_endereco=@id_endereco " +
                "WHERE id_filial = @id_filial";
            SqlParameter nm_filial = new SqlParameter("@nm_filial", SqlDbType.Text, 200);
            SqlParameter nr_cnpj = new SqlParameter("@nr_cnpj", SqlDbType.BigInt, 0);
            SqlParameter id_endereco = new SqlParameter("@id_endereco", SqlDbType.UniqueIdentifier, 0);
            SqlParameter id_filial = new SqlParameter("@id_filial", SqlDbType.UniqueIdentifier, 0);

            nm_filial.Value = filial.nm_filial;
            nr_cnpj.Value = filial.nr_cnpj;
            id_endereco.Value = filial.id_endereco;
            id_filial.Value = filial.id_filial;
            comando.Parameters.Add(nm_filial);
            comando.Parameters.Add(nr_cnpj);
            comando.Parameters.Add(id_endereco);
            comando.Parameters.Add(id_filial);

            comando.Prepare();
            comando.ExecuteNonQuery();

        }

        public Guid SqlCommandInsereSala(SqlConnection conexao, Sala sala)
        {
            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "INSERT INTO Sala (nm_sala) " +
                "OUTPUT INSERTED.id_sala " +
                "VALUES (@nm_sala)";
            SqlParameter nm_sala = new SqlParameter("@nm_sala", SqlDbType.Text, 200);

            nm_sala.Value = sala.nm_sala;
            comando.Parameters.Add(nm_sala);

            Guid id_sala = (Guid)comando.ExecuteScalar();

            return id_sala;

        }

        public void SqlCommandAtualizaSala(SqlConnection conexao, Sala sala)
        {
            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "UPDATE Sala SET nm_sala=@nm_sala " +
                "WHERE id_sala = @id_sala";
            SqlParameter nm_sala = new SqlParameter("@nm_sala", SqlDbType.Text, 200);
            SqlParameter id_sala = new SqlParameter("@id_sala", SqlDbType.UniqueIdentifier, 0);

            nm_sala.Value = sala.nm_sala;
            id_sala.Value = sala.id_sala;
            comando.Parameters.Add(nm_sala);
            comando.Parameters.Add(id_sala);

            comando.Prepare();
            comando.ExecuteNonQuery();

        }

        public Guid SqlCommandInsereResponsavel(SqlConnection conexao, Responsavel responsavel)
        {
            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "INSERT INTO Responsavel (nm_responsavel, nr_cpf, nr_telefone) " +
                "OUTPUT INSERTED.id_responsavel " +
                "VALUES (@nm_responsavel, @nr_cpf, @nr_telefone)";
            SqlParameter nm_responsavel = new SqlParameter("@nm_responsavel", SqlDbType.Text, 200);
            SqlParameter nr_cpf = new SqlParameter("@nr_cpf", SqlDbType.BigInt, 0);
            SqlParameter nr_telefone = new SqlParameter("@nr_telefone", SqlDbType.BigInt, 0);

            nm_responsavel.Value = responsavel.nm_responsavel;
            nr_cpf.Value = responsavel.nr_cpf;
            nr_telefone.Value = responsavel.nr_telefone;
            comando.Parameters.Add(nm_responsavel);
            comando.Parameters.Add(nr_cpf);
            comando.Parameters.Add(nr_telefone);

            Guid id_responsavel = (Guid)comando.ExecuteScalar();

            return id_responsavel;

        }

        public void SqlCommandAtualizaResponsavel(SqlConnection conexao, Responsavel responsavel)
        {
            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "UPDATE Responsavel SET nm_responsavel=@nm_responsavel, nr_cpf=@nr_cpf, nr_telefone=@nr_telefone " +
                "WHERE id_responsavel = @id_responsavel";
            SqlParameter nm_responsavel = new SqlParameter("@nm_responsavel", SqlDbType.Text, 200);
            SqlParameter nr_cpf = new SqlParameter("@nr_cpf", SqlDbType.BigInt, 0);
            SqlParameter nr_telefone = new SqlParameter("@nr_telefone", SqlDbType.BigInt, 0);
            SqlParameter id_responsavel = new SqlParameter("@id_responsavel", SqlDbType.UniqueIdentifier, 0);

            nm_responsavel.Value = responsavel.nm_responsavel;
            nr_cpf.Value = responsavel.nr_cpf;
            nr_telefone.Value = responsavel.nr_telefone;
            id_responsavel.Value = responsavel.id_responsavel;
            comando.Parameters.Add(nm_responsavel);
            comando.Parameters.Add(nr_cpf);
            comando.Parameters.Add(nr_telefone);
            comando.Parameters.Add(id_responsavel);

            comando.Prepare();
            comando.ExecuteNonQuery();

        }

        public Guid SqlCommandInsereReserva(SqlConnection conexao, Reserva reserva)
        {
            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "INSERT INTO Reserva (id_filial, id_sala, dt_inicio, dt_fim, id_responsavel, dv_cafe, qt_cafe, nm_descricao) " +
                "OUTPUT INSERTED.id_reserva " +
                "VALUES (@id_filial, @id_sala, @dt_inicio, @dt_fim, @id_responsavel, @dv_cafe, @qt_cafe, @nm_descricao)";
            SqlParameter id_filial = new SqlParameter("@id_filial", SqlDbType.UniqueIdentifier, 0);
            SqlParameter id_sala = new SqlParameter("@id_sala", SqlDbType.UniqueIdentifier, 0);
            SqlParameter dt_inicio = new SqlParameter("@dt_inicio", SqlDbType.DateTime, 0);
            SqlParameter dt_fim = new SqlParameter("@dt_fim", SqlDbType.DateTime, 0);
            SqlParameter id_responsavel = new SqlParameter("@id_responsavel", SqlDbType.UniqueIdentifier, 0);
            SqlParameter dv_cafe = new SqlParameter("@dv_cafe", SqlDbType.Bit, 0);
            SqlParameter qt_cafe = new SqlParameter("@qt_cafe", SqlDbType.SmallInt, 0);
            SqlParameter nm_descricao = new SqlParameter("@nm_descricao", SqlDbType.Text, 200);


            id_filial.Value = reserva.id_filial;
            id_sala.Value = reserva.id_sala;
            dt_inicio.Value = reserva.dt_inicio;
            dt_fim.Value = reserva.dt_fim;
            id_responsavel.Value = reserva.id_responsavel;
            dv_cafe.Value = reserva.dv_cafe;
            qt_cafe.Value = reserva.qt_cafe;
            nm_descricao.Value = reserva.nm_descricao;
            comando.Parameters.Add(id_filial);
            comando.Parameters.Add(id_sala);
            comando.Parameters.Add(dt_inicio);
            comando.Parameters.Add(dt_fim);
            comando.Parameters.Add(id_responsavel);
            comando.Parameters.Add(dv_cafe);
            comando.Parameters.Add(qt_cafe);
            comando.Parameters.Add(nm_descricao);

            Guid id_reserva = (Guid)comando.ExecuteScalar();

            return id_reserva;

        }

        public void SqlCommandAtualizaReserva(SqlConnection conexao, Reserva reserva)
        {
            SqlCommand comando = new SqlCommand(null, conexao);

            // Create and prepare an SQL statement.
            comando.CommandText =
                "UPDATE Reserva SET id_filial=@id_filial, id_sala=@id_sala, dt_inicio=@dt_inicio, dt_fim=@dt_fim, id_responsavel=@id_responsavel, dv_cafe=@dv_cafe, qt_cafe=@qt_cafe, nm_descricao=@nm_descricao " +
                "WHERE id_reserva = @id_reserva";
            SqlParameter id_filial = new SqlParameter("@id_filial", SqlDbType.UniqueIdentifier, 0);
            SqlParameter id_sala = new SqlParameter("@id_sala", SqlDbType.UniqueIdentifier, 0);
            SqlParameter dt_inicio = new SqlParameter("@dt_inicio", SqlDbType.DateTime, 0);
            SqlParameter dt_fim = new SqlParameter("@dt_fim", SqlDbType.DateTime, 0);
            SqlParameter id_responsavel = new SqlParameter("@id_responsavel", SqlDbType.UniqueIdentifier, 0);
            SqlParameter dv_cafe = new SqlParameter("@dv_cafe", SqlDbType.Bit, 0);
            SqlParameter qt_cafe = new SqlParameter("@qt_cafe", SqlDbType.SmallInt, 0);
            SqlParameter nm_descricao = new SqlParameter("@nm_descricao", SqlDbType.Text, 200);
            SqlParameter id_reserva = new SqlParameter("@id_reserva", SqlDbType.UniqueIdentifier, 0);

            id_filial.Value = reserva.id_filial;
            id_sala.Value = reserva.id_sala;
            dt_inicio.Value = reserva.dt_inicio;
            dt_fim.Value = reserva.dt_fim;
            id_responsavel.Value = reserva.id_responsavel;
            dv_cafe.Value = reserva.dv_cafe;
            qt_cafe.Value = reserva.qt_cafe;
            nm_descricao.Value = reserva.nm_descricao;
            id_reserva.Value = reserva.id_reserva;
            comando.Parameters.Add(id_filial);
            comando.Parameters.Add(id_sala);
            comando.Parameters.Add(dt_inicio);
            comando.Parameters.Add(dt_fim);
            comando.Parameters.Add(id_responsavel);
            comando.Parameters.Add(dv_cafe);
            comando.Parameters.Add(qt_cafe);
            comando.Parameters.Add(nm_descricao);
            comando.Parameters.Add(id_reserva);

            comando.Prepare();
            comando.ExecuteNonQuery();

        }
    }
}
