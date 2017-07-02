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

        public Retorno Sala(Stream sal)
        {
            try
            {

                StreamReader reader = new StreamReader(sal);
                string JSONdata = reader.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                Sala sala = jss.Deserialize<Sala>(JSONdata);

                Retorno retorno = new Retorno();

                if (sala == null)
                {
                    retorno.CodigoRetorno = 0;
                    retorno.DescricaoRetorno = "Falha ao deserializar";
                }
                else
                {
                    CadastroBancoDados banco = new CadastroBancoDados();

                    SqlConnection conexao = banco.abrirConexao();

                    if (sala.id_sala.ToString().Equals("00000000-0000-0000-0000-000000000000"))
                    {
                        retorno.guid = banco.SqlCommandInsereSala(conexao, sala);
                        retorno.CodigoRetorno = 1;
                        retorno.DescricaoRetorno = "Sala inserida";
                    }
                    else
                    {
                        banco.SqlCommandAtualizaSala(conexao, sala);
                        retorno.guid = sala.id_sala;
                        retorno.CodigoRetorno = 1;
                        retorno.DescricaoRetorno = "Sala atualizada";
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

        public Retorno Responsavel(Stream res)
        {
            try
            {

                StreamReader reader = new StreamReader(res);
                string JSONdata = reader.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                Responsavel responsavel = jss.Deserialize<Responsavel>(JSONdata);

                Retorno retorno = new Retorno();

                if (responsavel == null)
                {
                    retorno.CodigoRetorno = 0;
                    retorno.DescricaoRetorno = "Falha ao deserializar";
                }
                else
                {
                    CadastroBancoDados banco = new CadastroBancoDados();

                    SqlConnection conexao = banco.abrirConexao();

                    if (responsavel.id_responsavel.ToString().Equals("00000000-0000-0000-0000-000000000000"))
                    {
                        retorno.guid = banco.SqlCommandInsereResponsavel(conexao, responsavel);
                        retorno.CodigoRetorno = 1;
                        retorno.DescricaoRetorno = "Responsável inserido";
                    }
                    else
                    {
                        banco.SqlCommandAtualizaResponsavel(conexao, responsavel);
                        retorno.guid = responsavel.id_responsavel;
                        retorno.CodigoRetorno = 1;
                        retorno.DescricaoRetorno = "Responsável atualizado";
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

        public Retorno Reserva(Stream res)
        {
            try
            {

                StreamReader reader = new StreamReader(res);
                string JSONdata = reader.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                Reserva reserva = jss.Deserialize<Reserva>(JSONdata);

                Retorno retorno = new Retorno();

                if (reserva == null)
                {
                    retorno.CodigoRetorno = 0;
                    retorno.DescricaoRetorno = "Falha ao deserializar";
                }
                else
                {
                    Consulta conGetReservas = new Consulta();

                    List<Reserva> reservasintervalo = conGetReservas.GetReservasIntervalo(reserva.id_reserva, reserva.dt_inicio, reserva.dt_fim, reserva.id_sala, reserva.id_filial);

                    if (reservasintervalo.Count == 0)
                    {
                        CadastroBancoDados banco = new CadastroBancoDados();

                        SqlConnection conexao = banco.abrirConexao();

                        if (reserva.id_reserva.ToString().Equals("00000000-0000-0000-0000-000000000000"))
                        {
                            retorno.guid = banco.SqlCommandInsereReserva(conexao, reserva);
                            retorno.CodigoRetorno = 1;
                            retorno.DescricaoRetorno = "Reserva inserida";
                        }
                        else
                        {
                            banco.SqlCommandAtualizaReserva(conexao, reserva);
                            retorno.guid = reserva.id_reserva;
                            retorno.CodigoRetorno = 1;
                            retorno.DescricaoRetorno = "Reserva atualizada";
                        }

                        banco.fecharConexao(conexao);
                    }
                    else
                    {
                        Retorno retornoint = new Retorno();
                        retornoint.CodigoRetorno = 0;
                        retornoint.DescricaoRetorno = "Já existe reunião para o horário solicitado";
                        return retornoint;
                    }
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