using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBindingCommands
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DateTime data = DateTime.Now;
            Application.Current.Properties["dtAtual"] = data;
            Application.Current.Properties["AcaoInicial"] = string.Format(" * App executado às {0}. \n", data);

            MainPage = new MainPage();
        }

        protected override void OnStart()//Todo aplicativo programado tem os três( OnStart, Onsleep e OnReseume) serve OnStart Inicializa o app
        {

        }

        protected override void OnSleep()//Segundo plano do app, onde se calcula o tempo para expiração 
        {

        }

        protected override void OnResume()//Retorna ao app dando continuidade
        {

        }
    }
}
