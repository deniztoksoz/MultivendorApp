using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MultivendorAPP.Services;
using MultivendorAPP.Views;
using Xamarin.Essentials;

namespace MultivendorAPP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IAuth, Auth>();

            if (!String.IsNullOrEmpty(Preferences.Get("token", "")))
            {
                MainPage = new AppShell();
              
            }

            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
