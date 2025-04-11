using Microsoft.Maui.Graphics.Text;
using System.Reflection.Metadata.Ecma335;

namespace TipCalculator
{
    public partial class Pag2 : ContentPage
    {
        bool arredondaPraCima;
        bool arredondaPraBaixo;
        public Pag2()
        {
            InitializeComponent();
            tipPercentSlider.ValueChanged += (s, e) => CalculateTip();
        }
        private void OnNormalTip(object sender, EventArgs e)
        {
            tipPercentSlider.Value = 15;
        }

        private void OnGenerousTip(object sender, EventArgs e)
        {

        }

        private void CalculateTip()
        {
            double valor = Convert.ToDouble(billInput.Text);
            double percentualDaGorjeta = (tipPercentSlider.Value);
            double gorjeta = valor * (percentualDaGorjeta / 100);

            if (arredondaPraCima)
            {
                gorjeta = Math.Ceiling(gorjeta); // metodo tinha retorno entao tinha que jogar em uma variavel para conseguir retorna
            }
            if (arredondaPraBaixo)
            {
                gorjeta = Math.Floor(gorjeta);
            }

            double total = valor + gorjeta;

            //Manipular para aparecer em um elemento que ja existe
            tipOutput.Text = gorjeta.ToString("C"); // "C" transforma em moeda - Currency // Convert.ToString(gorjeta)
            totalOutput.Text = total.ToString("C");                                       // Convert.ToString(total)
        }

        private void roundUp_Clicked(object sender, EventArgs e)
        {
            arredondaPraCima = true;
            arredondaPraBaixo = false;
        }

        private void roundDown_Clicked(object sender, EventArgs e)
        {
            arredondaPraCima = false;
            arredondaPraBaixo = true;
        }
    }

} 