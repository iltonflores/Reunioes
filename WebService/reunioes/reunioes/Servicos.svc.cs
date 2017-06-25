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

        public List<Endereco> GetEnderecos(Guid id_endereco, String nm_cidade, int nr_cep, String nm_estado)
        {
            Consulta conGetEnderecos = new Consulta();

            List<Endereco> enderecos = conGetEnderecos.GetEnderecos(id_endereco, nm_cidade, nr_cep, nm_estado);

            return enderecos;
        }

        public Retorno ApagaEndereco(Guid id_endereco, Guid id_filial)
        {
            Remove remEndereco = new Remove();
            Retorno retorno = remEndereco.Endereco(id_endereco, id_filial);

            return retorno;
        }
    }
}
