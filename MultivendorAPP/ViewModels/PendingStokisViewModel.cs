using MultivendorAPP.Models;
using MultivendorAPP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MultivendorAPP.ViewModels
{
    class PendingStokisViewModel : INotifyPropertyChanged
    {
        public IStokis _rest => DependencyService.Get<IStokis>();
        public event PropertyChangedEventHandler PropertyChanged;


        private List<Users> user;

        public List<Users> User
        {
            get { return user; }
            set { user = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("User"));
            }
        }

        private Users Selectedime;

        public Users SelectedTime
        {
            get { return Selectedime; }
            set { Selectedime = value;
                approve();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedTime"));
            }
        }



        private bool isBusy;

        public bool isbusy
        {
            get { return isBusy; }
            set { isBusy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isbusy"));
            }
        }



        public PendingStokisViewModel()
        {
        
            GetPendingAgent();
        }

        private async void GetPendingAgent()
        {
            isbusy = true;
            var stream = Preferences.Get("token", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(stream);
            var tokenS = handler.ReadJwtToken(stream) as JwtSecurityToken;

            var jti = tokenS.Claims.First(claim => claim.Type == "nameid").Value;
            var toInt = Convert.ToInt32(jti);

            var result = await _rest.penAgent(toInt);

            User = result;
            isbusy = false;
        }


        private async void approve()
        {
            bool s = await App.Current.MainPage.DisplayAlert("Approve", "Approve agent under your name", "Okay", "Cancel");

            if(s)
            {
                var result = await _rest.ApproveAgent(SelectedTime.id);
                User.Clear();
                GetPendingAgent();
            }
        }
        
    }
}
