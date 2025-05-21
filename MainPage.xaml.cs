namespace BMICalc
{
    public partial class MainPage : ContentPage
    {
        private const double UmbralBajoPeso = 18.5;
        private const double UmbralNormal = 24.9;
        private const double UmbralSuperior = 29.9;

        public MainPage()
        {
            InitializeComponent();
        }

        private void ev_CalcularBMI(object sender, EventArgs e)
        {
            try
            {
                var peso = string.IsNullOrWhiteSpace(Peso.Text) ? 0 : double.Parse(Peso.Text);
                var altura = string.IsNullOrWhiteSpace(Altura.Text) ? 0 : (double.Parse(Altura.Text)) / 100;

                if (peso <= 0 || altura <= 0)
                {
                    throw new ArgumentException("Peso y altura deben ser mayores a 0.");
                }

                double imc = peso / (altura * altura);

                BMIResult.Text = imc.ToString("F2");

                string result = GetBMIMensaje(imc);

                //Disponible por estar usando ContentPage
                DisplayAlert("Resultado", result, "OK");
            }
            catch (FormatException)
            {
                DisplayAlert("Error", "Por favor ingrese valores numéricos válidos para peso y altura.", "OK");
            }
            catch (ArgumentException ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
            catch (Exception)
            {
                DisplayAlert("Error", "Ocurrió un error inesperado. Intente nuevamente.", "OK");
            }

        }

        private string GetBMIMensaje(double imc)
        {
            if (imc < UmbralBajoPeso)
            {
                return "Peso inferior al umbral";
            }
            else if(imc <= UmbralNormal)
            {
                return "Peso normal";

            } else if (imc <= UmbralSuperior)
            {
                return "Peso superior al umbral";
            }
            else
            {
                return "Obesidad";
            }
        }
    }

}
