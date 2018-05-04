using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;


		}

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO logica do programa

            // validãções
            string cep = CEP.Text.Trim();


            if (isValidCEP(cep))
            {

                try
                {
                    Endereco end = ViaCEPServico.BuscaEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2}, Bairro {3} - {0}, {1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO","Endereço não foi encontrado para o CEP " + cep + " informado","OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }

                
            }

        }

        private bool isValidCEP(string cep)
        {

            bool valido = true;

            if(cep.Length != 8)
            {
                //ERRO
                valido = false;
                DisplayAlert("ERRO","CEP inválido! CEP deve conter 8 caracteres.", "OK");
            }

            int NovoCEP = 0;

            if(!int.TryParse(cep, out NovoCEP))
            {
                //ERRO
                valido = false;
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter apenas números.", "OK");
            }

            return valido;
        }

	}
}
