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
    public class AgentRegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IAuth _rest => DependencyService.Get<IAuth>();
        public IStokis _restStokis => DependencyService.Get<IStokis>();

        public Command RegisterCommand { get; set; }

        private List<Users> stokis;
        public List<Users> Stokis
        {
            get { return stokis; }
            set { stokis = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Stokis"));
            }
        }

        private Users selectedItem;

        public Users SelectedTime
        {
            get { return selectedItem; }
            set { selectedItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedTime"));
            }
        }



        public Register userz { get; set; }

        public AgentRegisterViewModel(Register user)
        {
            userz = user;
            getStokis();
            RegisterCommand = new Command(Register);
        }


        public async void getStokis()
        {
            var result = await _restStokis.getStokis();
            if(result != null)
            {
                Stokis = result;
            }
        }

        private async void Register()
        {
            userz.StokisId = SelectedTime.id;
            var result = await _rest.Register(userz);

            if (result)
            {
                await App.Current.MainPage.Navigation.PushAsync(new SuccessRegister());
            }

            else
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Your registration fail", "Okay");
            }
        }
    }
}
