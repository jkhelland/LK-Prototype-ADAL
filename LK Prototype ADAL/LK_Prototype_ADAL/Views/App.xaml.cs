using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;


namespace LK_Prototype_ADAL.Views
{
    public partial class App : Application
    {
        public static AuthenticationResult authResult { get; set; }

        public App()
        {
            // InitializeComponent();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
