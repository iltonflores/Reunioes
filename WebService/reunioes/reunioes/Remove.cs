using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace reunioes
{
    public class Remove
    {
        public Retorno Endereco(Guid id_endereco, Guid id_filial)
        {
            RemoveBancoDados banco = new RemoveBancoDados();

            SqlConnection conexao = banco.abrirConexao();

            banco.RemoveEndereco(conexao, id_endereco, id_filial);

            banco.fecharConexao(conexao);

            Retorno retorno = new Retorno();
            retorno.CodigoRetorno = 1;
            retorno.DescricaoRetorno = "Endereço removido";

            return retorno;
        }

    }
}