using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace reunioes
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ChamadaServicos
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "postEndereco")]
        Retorno CadastraEndereco(Stream Endereco);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "postFilial")]
        Retorno CadastraFilial(Stream Filial);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "postSala")]
        Retorno CadastraSala(Stream Sala);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "postResponsavel")]
        Retorno CadastraResponsavel(Stream Responsavel);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "postReserva")]
        Retorno CadastraReserva(Stream Reserva);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteEndereco?id_endereco={id_enderecoParam}&id_filial={id_filialParam}")]
        Retorno ApagaEndereco(Guid id_enderecoParam, Guid id_filialParam);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteFilial?id_filial={id_filialParam}")]
        Retorno ApagaFilial(Guid id_filialParam);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteSala?id_sala={id_salaParam}")]
        Retorno ApagaSala(Guid id_salaParam);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteResponsavel?id_responsavel={id_responsavelParam}")]
        Retorno ApagaResponsavel(Guid id_responsavelParam);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteReserva?id_reserva={id_reservaParam}")]
        Retorno ApagaReserva(Guid id_reservaParam); 
        
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getEnderecos?id_endereco={id_enderecoParam}&nm_cidade={nm_cidadeParam}&nr_cep={nr_cepParam}&nm_estado={nm_estadoParam}")]
        List<Endereco> GetEnderecos(Guid id_enderecoParam, String nm_cidadeParam, int nr_cepParam, String nm_estadoParam);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getFiliais?id_filial={id_filialParam}&nr_cnpj={nr_cnpjParam}")]
        List<Filial> GetFiliais(Guid id_filialParam, Int64 nr_cnpjParam);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getSalas?id_sala={id_salaParam}&nm_sala={nm_salaParam}")]
        List<Sala> GetSalas(Guid id_salaParam, String nm_salaParam);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getResponsaveis?id_responsavel={id_responsavelParam}&nr_cpf={nr_cpfParam}")]
        List<Responsavel> GetResponsaveis(Guid id_ResponsavelParam, Int64 nr_cpfParam);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getReservas?id_reserva={id_reservaParam}&dt_inicio={dt_inicioParam}&dt_fim={dt_fimParam}&id_sala={id_salaParam}&id_filial={id_filialParam}")]
        List<Reserva> GetReservas(Guid id_reservaParam, DateTime dt_inicioParam, DateTime dt_fimParam, Guid id_salaParam, Guid id_filialParam);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getReservasTextoLista?id_reserva={id_reservaParam}&dt_inicio={dt_inicioParam}&dt_fim={dt_fimParam}&id_sala={id_salaParam}&id_filial={id_filialParam}")]
        List<ReservaTextoLista> GetReservasTextoLista(Guid id_reservaParam, DateTime dt_inicioParam, DateTime dt_fimParam, Guid id_salaParam, Guid id_filialParam);
    }
}
