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
    }
}