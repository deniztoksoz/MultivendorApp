using MultivendorAPP.Models;
using MultivendorAPP.Services;
using MultivendorAPP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MultivendorAPP.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IAuth _rest => DependencyService.Get<IAuth>();
        public Command RegisterPage { get; set; }
        public Command LoginCommand { get; set; }

        private Token user;

        public Token User
        {
            get { return user; }
            set { user = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("User"));
            }
        }


        private bool enable;

        public bool Enable
        {
            get { return enable; }
            set { enable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Enable"));
            }
        }


        private bool loading;

        public bool Loading
        {
            get { return loading; }
            set { loading = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Loading"));
            }
        }



        public LoginViewModel()
        {
            Loading = false;
            Enable = true;
            RegisterPage = new Command(GoTo);
            LoginCommand = new Command(login);
        }
        private async void GoTo()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        private async void login()
        {
            Loading = true;
            Enable = false;
            if (User.Email != null && User.Password != null)
            {
                try
                {
                    var result = await _rest.Login(User.Email, User.Password);

                    if (result != null)
                    {
                        Preferences.Set("token", result.token);
                        Application.Current.MainPage = new AppShell();
                    }

                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Failed to login", "Check your email and password", "Okay");
                    }
                }

                catch (Exception ex)
                {

                    await Application.Current.MainPage.DisplayAlert("Ops!", ex.ToString(), "Okay");
                }

            }

            else
            {
                await Application.Current.MainPage.DisplayAlert("Emtpy", "Check your email and password", "Okay");
            }

            Loading = false;
            Enable = true;
        }


    }
}
