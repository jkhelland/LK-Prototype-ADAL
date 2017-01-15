using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using UIKit;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;

[assembly: Dependency(typeof(LK_Prototype_ADAL.iOS.Helpers.AuthenticationHelper))]
namespace LK_Prototype_ADAL.iOS.Helpers
{
    class AuthenticationHelper : IAuthenticator
    {
        public async Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri)
        {
            var authContext = new AuthenticationContext(authority);
            if (authContext.TokenCache.ReadItems().Any())
                authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);
            var authResult = await authContext.AcquireTokenAsync(resource, clientId, new Uri(returnUri),
                new PlatformParameters(UIApplication.SharedApplication.KeyWindow.RootViewController));
            return authResult;
        }
    }
}
