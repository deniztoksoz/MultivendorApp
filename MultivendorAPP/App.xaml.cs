using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MultivendorAPP.Services;
using MultivendorAPP.Views;
using Xamarin.Essentials;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace MultivendorAPP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IAuth, Auth>();
            DependencyService.Register<IStokis, Stokis>();



            if (!String.IsNullOrEmpty(Preferences.Get("token", "")))
            {


                var stream = Preferences.Get("token", "");
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(stream);
                var tokenS = handler.ReadJwtToken(stream) as JwtSecurityToken;

                var jti = tokenS.Claims.First(claim => claim.Type == "role").Value;
                if(jti == "Stokis")
                {
                    MainPage = new AppShellStokis();
                }

                else
                {
                    MainPage = new AppShell();
                }
            
              
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
