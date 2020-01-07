using MultivendorAPP.Models;
using MultivendorAPP.Services;
using MultivendorAPP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MultivendorAPP.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IAuth _rest => DependencyService.Get<IAuth>();
        public Command RegisterPage { get; set; }

        private Token user;

        public Token User
        {
            get { return user; }
            set { user = value; }
        }


        public LoginViewModel()
        {
            RegisterPage = new Command(GoTo);
        }
        private async void GoTo()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        private async void login()
        {
            var result = await _rest.Login(User.Email, User.Password);

            if(result != null)
            {

            }

            else
            {

            }

        }
    }
}
