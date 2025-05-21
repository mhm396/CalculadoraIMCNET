namespace BMICalc
{//Aqui inica todo el proyecto
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage(); //Se crea una instancia de la clase AppShell (ver AppShell.xaml)
        }
    }
}
