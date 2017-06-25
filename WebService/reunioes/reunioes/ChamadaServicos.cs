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
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteEndereco?id_endereco={id_enderecoParam}&id_filial={id_filialParam}")]
        Retorno ApagaEndereco(Guid id_enderecoParam, Guid id_filialParam);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deleteFilial?id_filial={id_filialParam}")]
        Retorno ApagaFilial(Guid id_filialParam); 
        
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getEnderecos?id_endereco={id_enderecoParam}&nm_cidade={nm_cidadeParam}&nr_cep={nr_cepParam}&nm_estado={nm_estadoParam}")]
        List<Endereco> GetEnderecos(Guid id_enderecoParam, String nm_cidadeParam, int nr_cepParam, String nm_estadoParam);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getFiliais?id_filial={id_filialParam}&nr_cnpj={nr_cnpjParam}")]
        List<Filial> GetFiliais(Guid id_filialParam, Int64 nr_cnpjParam);
    }
}
