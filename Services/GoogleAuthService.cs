using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Auth;

namespace DDDNetCore.Services
{
    public class GoogleAuthService(string clientId)
    {
        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleTokenAsync(string token)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string>() { clientId }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);
            return payload;
        }
    }
}