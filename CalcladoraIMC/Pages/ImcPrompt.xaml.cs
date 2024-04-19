using System.ComponentModel;

namespace CalcladoraIMC.Pages;

public partial class ImcPrompt : ContentPage
{

    public ImcPrompt()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        //var altura = double.Parse(Altura.Text);
        //var peso = double.Parse(Peso.Text);

        double altura = 0;
        double peso = 0;

        bool alturaParseSuccess = double.TryParse(Altura.Text, out altura);
        bool pesoParseSuccess = double.TryParse(Peso.Text, out peso);

          if (!alturaParseSuccess || !pesoParseSuccess)
        {
            DisplayAlert("AVISO!", "Altura e/ou peso inválidos. Por favor, digite valores numéricos.", "Ok ;(");
            return;
        }

        if (altura <= 0 || peso <= 0) 
        {
            DisplayAlert("AVISO!", "Coloque uma Altura/Pesso validos", "Ok ;(");
        }
       

        altura = altura / 100;

        var imc = peso / (altura * altura);


        if (imc >= 0)
        IMC.Text = imc.ToString("F2");


        if (imc > 0 && imc < 18.50)
        {
            Resultado.Text = "Abaixo do Peso!";
        }
        if (imc >= 18.60 && imc < 24.99)
        {
            Resultado.Text = "PESO IDEAL!\n Parabens, continue assim meu caro padawan!";
        }
        if (imc >= 25 && imc < 29.99)
        {
            Resultado.Text = "Levemente acima do peso!";
        }
        if (imc >= 30 && imc < 34.99)
        {
            Resultado.Text = "Obesidade Grau I!";
        }
        if (imc >= 35 && imc < 39.99)
        {
            Resultado.Text = "Obesidade Grau II!";
        }
        if (imc >= 40)
        {
            Resultado.Text = "Obesidade Grau III!";
        }
    }
}