using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace LK_Prototype_ADAL
{
    public interface IAuthenticator
    {
        Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri);
    }
}
