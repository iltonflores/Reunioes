using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace reunioes
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Servicos : ChamadaServicos
    {
        public Retorno CadastraEndereco(Stream end)
        {
            Cadastro cadEndereco = new Cadastro();
            Retorno retorno = cadEndereco.Endereco(end);

            return retorno;
        }

        public Retorno CadastraFilial(Stream fil)
        {
            Cadastro cadFilial = new Cadastro();
            Retorno retorno = cadFilial.Filial(fil);

            return retorno;
        }

        public Retorno CadastraSala(Stream sal)
        {
            Cadastro cadSala = new Cadastro();
            Retorno retorno = cadSala.Sala(sal);

            return retorno;
        }

        public Retorno CadastraResponsavel(Stream res)
        {
            Cadastro cadResponsavel = new Cadastro();
            Retorno retorno = cadResponsavel.Responsavel(res);

            return retorno;
        }

        public Retorno CadastraReserva(Stream res)
        {
            Cadastro cadReserva = new Cadastro();
            Retorno retorno = cadReserva.Reserva(res);

            return retorno;
        }

        public List<Endereco> GetEnderecos(Guid id_endereco, String nm_cidade, int nr_cep, String nm_estado)
        {
            Consulta conGetEnderecos = new Consulta();

            List<Endereco> enderecos = conGetEnderecos.GetEnderecos(id_endereco, nm_cidade, nr_cep, nm_estado);

            return enderecos;
        }

        public List<Filial> GetFiliais(Guid id_filial, Int64 nr_cnpj)
        {
            Consulta conGetFiliais = new Consulta();

            List<Filial> filiais = conGetFiliais.GetFiliais(id_filial, nr_cnpj);

            return filiais;
        }

        public List<Sala> GetSalas(Guid id_sala, String nm_sala)
        {
            Consulta conGetSalas = new Consulta();

            List<Sala> salas = conGetSalas.GetSalas(id_sala, nm_sala);

            return salas;
        }

        public List<Responsavel> GetResponsaveis(Guid id_responsavel, Int64 nr_cpf)
        {
            Consulta conGetResponsaveis = new Consulta();

            List<Responsavel> responsaveis = conGetResponsaveis.GetResponsaveis(id_responsavel, nr_cpf);

            return responsaveis;
        }

        public List<Reserva> GetReservas(Guid id_reserva, DateTime dt_inicio, DateTime dt_fim, Guid id_sala, Guid id_filial)
        {
            Consulta conGetReservas = new Consulta();

            List<Reserva> reservas = conGetReservas.GetReservas(id_reserva, dt_inicio, dt_fim, id_sala, id_filial);

            return reservas;
        }

        public Retorno ApagaEndereco(Guid id_endereco, Guid id_filial)
        {
            Remove remEndereco = new Remove();
            Retorno retorno = remEndereco.Endereco(id_endereco, id_filial);

            return retorno;
        }

        public Retorno ApagaFilial(Guid id_filial)
        {
            Remove remFilial = new Remove();
            Retorno retorno = remFilial.Filial(id_filial);

            return retorno;
        }
    }
}
