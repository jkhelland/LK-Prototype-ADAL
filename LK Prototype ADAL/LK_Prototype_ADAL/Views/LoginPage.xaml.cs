using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LK_Prototype_ADAL.Views
{
    public partial class LoginPage : ContentPage
    {
        public static string clientId = "45c2d41c-8b37-43f7-a7ca-adc24174b2f1";
        public static string tenant = "johnkenneth.onmicrosoft.com";
        public static string authority = String.Format("https://login.microsoftonline.com/{0}", tenant);
        public static string returnUri = "http://lk-prototype-redirect";
        private const string graphResourceUri = "https://graph.windows.net";
        public static string graphApiVersion = "2013-11-08";
        //private AuthenticationResult authResult = null;

        protected override async void OnAppearing()
        {
            try
            {
                if(App.authResult != null)
                {
                    var userName = App.authResult.UserInfo.GivenName + " " + App.authResult.UserInfo.FamilyName;
                    await DisplayAlert("Token", "Allerede logget inn " + userName, "OK");
                    //await Navigation.PushAsync(new MainPage());
                }     
            }
            catch { }
        }

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnSignIn_OnClicked(object sender, EventArgs e)
        {
            App.authResult = await DependencyService.Get<IAuthenticator>()
                .Authenticate(authority, graphResourceUri, clientId, returnUri);

            var userName = App.authResult.UserInfo.GivenName + " " + App.authResult.UserInfo.FamilyName;
            //await DisplayAlert("Token", "Welcome " + userName, "Ok", "Cancel");
            await Navigation.PushModalAsync(new MainPage());

            if (App.authResult.AccessToken != null)
            {
                //await Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Token", "Login failed", "Ok", "Cancel");
            }

            
        }
    }
}
