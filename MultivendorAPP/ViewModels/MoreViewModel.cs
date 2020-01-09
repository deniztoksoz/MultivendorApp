using MultivendorAPP.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MultivendorAPP.ViewModels
{
    public class MoreViewModel
    {
        public Command LogoutCommand { get; set; }
        public MoreViewModel()
        {
            LogoutCommand = new Command(logout);
        }

        private async void logout()
        {
            var isSignOut = await Application.Current.MainPage.DisplayAlert("Are you sure", "You can always come back", "Yes", "Cancel");

            if (isSignOut)
            {
                Preferences.Remove("token");

                if (String.IsNullOrEmpty(Preferences.Get("token", "")))
                {
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                }

                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "cannot sign out", "cancel");
                }
            }
        }
    }
}
