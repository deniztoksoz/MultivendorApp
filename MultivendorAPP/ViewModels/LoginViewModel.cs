using MultivendorAPP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MultivendorAPP.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command RegisterPage { get; set; }
        public LoginViewModel()
        {
            RegisterPage = new Command(GoTo);
        }
        private async void GoTo()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
