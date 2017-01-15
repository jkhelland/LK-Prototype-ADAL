using System;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;

[assembly: Dependency(typeof(LK_Prototype_ADAL.Droid.Helpers.AuthenticationHelper))]
namespace LK_Prototype_ADAL.Droid.Helpers
{
    class AuthenticationHelper : IAuthenticator
    {
        public async Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri)
        {
            var authContext = new AuthenticationContext(authority);
            if (authContext.TokenCache.ReadItems().Any())
                authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);
            var authResult = await authContext.AcquireTokenAsync(resource, clientId, new Uri(returnUri), new PlatformParameters((Activity)Forms.Context));
            return authResult;
        }
    }
}