using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace reunioes
{
    public class Cadastro
    {
        public Retorno Endereco(Stream end)
        {
            try
            {

                StreamReader reader = new StreamReader(end);
                string JSONdata = reader.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                Endereco endereco = jss.Deserialize<Endereco>(JSONdata);

                Retorno retorno = new Retorno();

                if (endereco == null)
                {
                    retorno.CodigoRetorno = 0;
                    retorno.DescricaoRetorno = "Falha ao deserializar";
                }
                else
                {
                    CadastroBancoDados banco = new CadastroBancoDados();

                    SqlConnection conexao = banco.abrirConexao();

                    if (endereco.id_endereco.ToString().Equals("00000000-0000-0000-0000-000000000000"))
                    {
                        retorno.guid = banco.SqlCommandInsereEndereco(conexao, endereco);
                        retorno.CodigoRetorno = 1;
                        retorno.DescricaoRetorno = "Endereço inserido";
                    }
                    else
                    {
                        banco.SqlCommandAtualizaEndereco(conexao, endereco);
                        retorno.guid = endereco.id_endereco;
                        retorno.CodigoRetorno = 1;
                        retorno.DescricaoRetorno = "Endereço atualizado";
                    }

                    banco.fecharConexao(conexao);
                }
                return retorno;
            }
            catch (Exception error)
            {
                Retorno retorno = new Retorno();
                retorno.CodigoRetorno = 0;
                retorno.DescricaoRetorno = "Ocorreu o erro:" + error.Message;
                return retorno;
            }
        }

        public Retorno Filial(Stream fil)
        {
            try
            {

                StreamReader reader = new StreamReader(fil);
                string JSONdata = reader.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                Filial filial = jss.Deserialize<Filial>(JSONdata);

                Retorno retorno = new Retorno();

                if (filial == null)
                {
                    retorno.CodigoRetorno = 0;
                    retorno.DescricaoRetorno = "Falha ao deserializar";
                }
                else
                {
                    CadastroBancoDados banco = new CadastroBancoDados();

                    SqlConnection conexao = banco.abrirConexao();

                    if (filial.id_filial.ToString().Equals("00000000-0000-0000-0000-000000000000"))
                    {
                        retorno.guid = banco.SqlCommandInsereFilial(conexao, filial);
                        retorno.CodigoRetorno = 1;
                        retorno.DescricaoRetorno = "Filial inserida";
                    }
                    else
                    {
                        banco.SqlCommandAtualizaFilial(conexao, filial);
                        retorno.guid = filial.id_filial;
                        retorno.CodigoRetorno = 1;
                        retorno.DescricaoRetorno = "Filial atualizada";
                    }

                    banco.fecharConexao(conexao);
                }
                return retorno;
            }
            catch (Exception error)
            {
                Retorno retorno = new Retorno();
                retorno.CodigoRetorno = 0;
                retorno.DescricaoRetorno = "Ocorreu o erro:" + error.Message;
                return retorno;
            }
        }
    }
}