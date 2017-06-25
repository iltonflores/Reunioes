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
    }
}