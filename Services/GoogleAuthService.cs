using Google.Apis.Auth;
using System.Threading.Tasks;
using System.Collections.Generic;

public class GoogleAuthService
{
    private readonly string _clientId;

    public GoogleAuthService(string clientId)
    {
        _clientId = clientId;
    }

    public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleTokenAsync(string token)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string>() { _clientId }
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);
        return payload;
    }
}