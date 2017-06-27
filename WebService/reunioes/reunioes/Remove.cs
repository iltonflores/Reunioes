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

        public Retorno Filial(Guid id_filial)
        {
            RemoveBancoDados banco = new RemoveBancoDados();

            SqlConnection conexao = banco.abrirConexao();

            banco.RemoveFiliais(conexao, id_filial);

            banco.fecharConexao(conexao);

            Retorno retorno = new Retorno();
            retorno.CodigoRetorno = 1;
            retorno.DescricaoRetorno = "Filial removida";

            return retorno;
        }

        public Retorno Sala(Guid id_sala)
        {
            RemoveBancoDados banco = new RemoveBancoDados();

            SqlConnection conexao = banco.abrirConexao();

            banco.RemoveSala(conexao, id_sala);

            banco.fecharConexao(conexao);

            Retorno retorno = new Retorno();
            retorno.CodigoRetorno = 1;
            retorno.DescricaoRetorno = "Sala removida";

            return retorno;
        }

        public Retorno Responsavel(Guid id_responsavel)
        {
            RemoveBancoDados banco = new RemoveBancoDados();

            SqlConnection conexao = banco.abrirConexao();

            banco.RemoveResponsavel(conexao, id_responsavel);

            banco.fecharConexao(conexao);

            Retorno retorno = new Retorno();
            retorno.CodigoRetorno = 1;
            retorno.DescricaoRetorno = "Responsável removido";

            return retorno;
        }

        public Retorno Reserva(Guid id_reserva)
        {
            RemoveBancoDados banco = new RemoveBancoDados();

            SqlConnection conexao = banco.abrirConexao();

            banco.RemoveReserva(conexao, id_reserva, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"));

            banco.fecharConexao(conexao);

            Retorno retorno = new Retorno();
            retorno.CodigoRetorno = 1;
            retorno.DescricaoRetorno = "Reserva removida";

            return retorno;
        }

    }
}