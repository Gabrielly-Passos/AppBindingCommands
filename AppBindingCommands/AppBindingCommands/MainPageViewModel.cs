﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AppBindingCommands
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

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
    }
}