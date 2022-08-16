using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace AppBindingCommands
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand ShowMessageCommand;//Declara os botões na classe.

        private string name = string.Empty;//CTRL + R + E

        public string Name //Se comunica apenas se efetuar o encapsulamento
        {
            get => name; // => significa return
            set
            {
                if (name == null)
                    return;

                name = value;
                OnPropertyChanged(nameof(Name));//Fala com a tela que houve alteração e envia notificação para tela.
                OnPropertyChanged(nameof(DisplayName));
            }
        }
        public string DisplayName => $"Nome Digitado: {name}"; //Prop Tab

        string displayMessage = string.Empty;

        public string DisplayMessage
        {
            get => displayMessage;
            set
            {
                if (DisplayMessage == null)
                    return;

                displayMessage = value;
                OnPropertyChanged(nameof(DisplayMessage));
            }


        }

        public void ShowMessage()//Vincula ao metódo 
        {
            string dataProperty = Application.Current.Properties["dtAtual"].ToString();

            DisplayMessage = $"Boa noite {Name}. Hoje é {dataProperty}";

        }

        public MainPageViewModel()
        {
            ShowMessageCommand = new Command(ShowMessage);
            CountCommand = new Command(async () => await CountCharacters());
            CleanCommand = new Command(async () => await CleanConfirmation());
            OptionCommand = new Command(async () => await ShowOptions());

        }

        public ICommand CountCommand { get; }

        public async Task CountCharacters()
        {
            string nameLength =
                 string.Format("Seu nome tem {0} Letras", name.Length);

            await Application.Current.MainPage
                .DisplayAlert("Informação", "Limpeza realizada com sucesso", "Ok");


        }

        public ICommand CleanCommand { get; }

        public async Task CleanConfirmation()
        {
            if (await Application.Current.MainPage.DisplayAlert("Confirmação", "Confirma limpeza dos dados?", "Yes", "No"))
            {
                Name = String.Empty;
                DisplayMessage = String.Empty;
                OnPropertyChanged(Name);
                OnPropertyChanged(DisplayMessage);

                await Application.Current.MainPage
                    .DisplayAlert("Informação", "Limpeza realizada com sucesso", "Ok");
            }
        }

        public ICommand OptionCommand { get; }
        public async Task ShowOptions()
        {
            string result;
            result = await Application.Current.MainPage
                .DisplayActionSheet("Seleção", "Selecione uma opção", "Cancelar", "Limpar", "Contar Caracteres", "Exibir saudação");

            if (result != null)
            {
                if (result.Equals("Limpar"))
                    await CleanConfirmation();

                if (result.Equals("Contar Carcteres"))
                    await CountCharacters();

                if (result.Equals("Exibir Saudação"))
                    ShowMessage();

            }

        }
       
      































































    }
}