﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;

[assembly: Dependency(typeof(LK_Prototype_ADAL.WinPhone.Helpers.AuthenticationHelper))]
namespace LK_Prototype_ADAL.WinPhone.Helpers
{
    class AuthenticationHelper : IAuthenticator
    {
        public async Task<AuthenticationResult> Authenticate(string authority, string resource,
            string clientId, string returnUri)
        {
            var authContext = new AuthenticationContext(authority);
            if (authContext.TokenCache.ReadItems().Any())
                authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);
            var authResult = await authContext.AcquireTokenAsync(resource, clientId, new Uri(returnUri),
                new PlatformParameters());
            return authResult;
        }
    }
}
