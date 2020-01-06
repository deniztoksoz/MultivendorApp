using MultivendorAPP.Models;
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


        private Users user;

        public Users User
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

        private async void Register()
        {
            User = new Users();
            user.email = Email;
            user.name = Name;
            user.Password = compass;
            user.Phone = Phone;
            user.masterId = 0;
            user.facebook = Facebook;
            user.level = Level;
            user.address = Address;

           if(user.name != null && user.email != null && user.facebook != null && user.level != null && user.address != null && user.level != null && user.Password != null)
            {
                if (user.name != "" && user.email != "" && user.facebook != "" && user.level != "" && user.address != "" && user.level != "" && user.Password != "")
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Make sure you fill all the blank", "Okay");
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
