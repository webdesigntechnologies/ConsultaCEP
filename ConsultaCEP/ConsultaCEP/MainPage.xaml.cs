using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultaCEP.Services.Models;
using Xamarin.Forms;

namespace ConsultaCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Search_OnClicked(object sender, EventArgs e)
        {
            if (isValidCEP(Search.Text))
            {
                try
                {
                    Address address = ViaCEP.SearchCEP(Search.Text.Trim());

                    if (address != null)
                    {
                        CEP.Text = address.CEP;
                        Logradouro.Text = address.Localidade;
                        Complemento.Text = address.Complemento;
                        Bairro.Text = address.Bairro;
                        Localidade.Text = address.Localidade;
                        UF.Text = address.UF;
                        Unidade.Text = address.Unidade;
                        IBGE.Text = address.IBGE;
                        GIA.Text = address.GIA;

                        LayoutSearch.IsVisible = false;
                        LayoutResult.IsVisible = true;
                    }
                    else
                    {
                        DisplayAlert("Erro", $"O endereço não foi encontrado para o CEP informado: {Search.Text}", "OK");
                    }
                }
                catch (Exception exception)
                {
                    DisplayAlert("Error", exception.Message, "OK");
                }
            }
        }

        private void BackButton_OnClicked(object sender, EventArgs e)
        {
            LayoutSearch.IsVisible = true;
            LayoutResult.IsVisible = false;
        }

        private bool isValidCEP(string cep)
        {
            bool valid = true;

            if (cep.Length != 8)
            {
                DisplayAlert("Error", "CEP inválido!\nO CEP deve conter 8 caracteres.", "OK");
                valid = false;
            }

            int newCEP = 0;
            if (!int.TryParse(cep, out newCEP))
            {
                DisplayAlert("Error", "CEP inválido!\nO CEP deve ser composto apenas por números.", "OK");
                valid = false;
            }

            return true;
        }
    }
}
