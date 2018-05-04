using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico.Modelo
{
    public class ViaCEPServico
    {
        //o {0} deixa base para ser substituído com o stringFormat
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscaEnderecoViaCEP(string cep)
        {
            //formando novo endereço com base no parâmetro passado
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();

            //fazendo download das informacoes e colocando dentro de CONTEUDO
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            //pegando os dados da internet e colocando dentro do END, que é um objeto do tipo ENDERECO
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return end;

        }
    }
}
