using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace reunioes
{
    public class Consulta
    {
        public List<Endereco> GetEnderecos(Guid id_endereco, String nm_cidade, int nr_cep, String nm_estado)
        {
            List<Endereco> enderecos = new List<Endereco>();
            try
            {
                ConsultaBancoDados banco = new ConsultaBancoDados();

                SqlConnection conexao = banco.abrirConexao();

                enderecos = banco.SqlCommandConsultaEndereco(conexao, id_endereco, nm_cidade, nr_cep, nm_estado);

                banco.fecharConexao(conexao);
                return enderecos;
            }
            catch (Exception error)
            {

                Endereco endereco = new Endereco();
                endereco.id_endereco = new Guid();
                endereco.nm_cidade = "Ocorreu o erro:" + error.Message;
                enderecos.Add(endereco);

                return enderecos;
            }

        }

        public List<Filial> GetFiliais(Guid id_filial, Int64 nr_cnpj)
        {
            List<Filial> filiais = new List<Filial>();
            try
            {
                ConsultaBancoDados banco = new ConsultaBancoDados();

                SqlConnection conexao = banco.abrirConexao();

                filiais = banco.SqlCommandConsultaFilial(conexao, id_filial, nr_cnpj);

                banco.fecharConexao(conexao);
                return filiais;
            }
            catch (Exception error)
            {

                Filial filial = new Filial();
                filial.id_filial = new Guid();
                filial.nm_filial = "Ocorreu o erro:" + error.Message;
                filiais.Add(filial);

                return filiais;
            }

        }

        public List<Sala> GetSalas(Guid id_sala, String nm_sala)
        {
            List<Sala> salas = new List<Sala>();
            try
            {
                ConsultaBancoDados banco = new ConsultaBancoDados();

                SqlConnection conexao = banco.abrirConexao();

                salas = banco.SqlCommandConsultaSala(conexao, id_sala, nm_sala);

                banco.fecharConexao(conexao);
                return salas;
            }
            catch (Exception error)
            {

                Sala sala = new Sala();
                sala.id_sala = new Guid();
                sala.nm_sala = "Ocorreu o erro:" + error.Message;
                salas.Add(sala);

                return salas;
            }

        }

        public List<Responsavel> GetResponsaveis(Guid id_responsavel, Int64 nr_cpf)
        {
            List<Responsavel> responsaveis = new List<Responsavel>();
            try
            {
                ConsultaBancoDados banco = new ConsultaBancoDados();

                SqlConnection conexao = banco.abrirConexao();

                responsaveis = banco.SqlCommandConsultaResponsavel(conexao, id_responsavel, nr_cpf);

                banco.fecharConexao(conexao);
                return responsaveis;
            }
            catch (Exception error)
            {

                Responsavel responsavel = new Responsavel();
                responsavel.id_responsavel = new Guid();
                responsavel.nm_responsavel = "Ocorreu o erro:" + error.Message;
                responsaveis.Add(responsavel);

                return responsaveis;
            }

        }

        public List<Reserva> GetReservas(Guid id_reserva, DateTime dt_inicio, DateTime dt_fim, Guid id_sala, Guid id_filial)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                ConsultaBancoDados banco = new ConsultaBancoDados();

                SqlConnection conexao = banco.abrirConexao();

                reservas = banco.SqlCommandConsultaReserva(conexao, id_reserva, dt_inicio, dt_fim, id_sala, id_filial);

                banco.fecharConexao(conexao);
                return reservas;
            }
            catch (Exception error)
            {

                Reserva reserva = new Reserva();
                reserva.id_reserva = new Guid();
                reserva.nm_descricao = "Ocorreu o erro:" + error.Message;
                reservas.Add(reserva);

                return reservas;
            }

        }
    }
}