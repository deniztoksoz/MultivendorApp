using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MultivendorAPP.ViewModels
{
    public class SuccessViewModel
    {
        public Command BackLoginCommand { get; set; }
        public SuccessViewModel()
        {
            BackLoginCommand = new Command(back);
        }

        private async void back()
        {
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}
