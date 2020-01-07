using MultivendorAPP.Models;
using MultivendorAPP.Services;
using MultivendorAPP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MultivendorAPP.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IAuth _rest => DependencyService.Get<IAuth>();

        private List<string> vs;

        public List<string> LevelPicker
        {
            get { return vs; }
            set { vs = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Level"));
            }
        }



        //-----------

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
                CheckPassword();
            }
        }

        private string compass;

        public string Compass
        {
            get { return compass; }
            set { compass = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Compass"));
                CheckPassword();
            }
        }

        private string error;

        public string Error
        {
            get { return error; }
            set { error = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Error"));
            }
        }


        private Register user;

        public Register User
        {
            get { return user; }
            set { user = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("User"));
            }
        }


        public Command CreateAcc { get; set; }
        //----------

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Facebook { get; set; }
        public string Level { get; set; }

        //----



        public RegisterViewModel()
        {
            LevelPicker = new List<string>();
            LevelPicker.Add("Stokis");
            LevelPicker.Add("Agent");
            Error = "#4AD69E";

            CreateAcc = new Command(Register);
        }

        private void Register()
        {
            User = new Register();
            User.Email = Email;
            User.Name = Name;
            User.Password = compass;
            User.Phone = Phone;
            User.MasterId = 0;
            User.Facebook = Facebook;
            User.Level = Level;
            User.Address = Address;

            if(User.Level == "Stokis")
            {
                StokisRegister();
            }

            else
            {
                AgentRegister();
            }

        }

        private async void StokisRegister()
        {

    
            if (User.Name != null && User.Email != null && User.Facebook != null && User.Level != null && User.Address != null && User.Level != null && User.Password != null)
            {
                if (User.Name != "" && User.Email != "" && User.Facebook != "" && User.Level != "" && User.Address != "" && User.Level != "" && User.Password != "")
                {
                   
                        var result = await _rest.Register(User);

                        if (result)
                        {

                        }

                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Failed", "Your registration fail", "Okay");
                        }
                    
                 
                }

                else
                {
                    await App.Current.MainPage.DisplayAlert("Ops", "Make sure you fill all the blank", "Okay");
                }
            }

            else
            {
                await App.Current.MainPage.DisplayAlert("Ops", "Make sure you fill all the blank", "Okay");
            }
        }
        private async void AgentRegister()
        {
            AgentRegisterPage page = new AgentRegisterPage();
            page.BindingContext = new AgentRegisterViewModel(User);
            await App.Current.MainPage.Navigation.PushAsync(page);
        }

        public void CheckPassword()
        {
            if(password != compass)
            {
                Error = "Red";
            }

            else
            {
                Error = "#4AD69E";
            }
        }
     
    }
}
