using Azure.Communication.Identity;
using System;
using System.Threading.Tasks;
using Azure.Communication;


namespace GetCommunicationToken
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "endpoint=https://mughuacs.communication.azure.com/;accesskey=ms9CMe37Z8gFfWjkuM53TrA8YM0K08kHJ1rKYyDDa9YtXnxbozTeO9nRYKefTvI9lfmiFlQJFgU333CO7wdsYQ==";
            var client = new CommunicationIdentityClient(connectionString);

            // Issue an identity and an access token with the "voip" scope for the new identity
            var identityAndTokenResponse = await client.CreateUserAndTokenAsync(scopes: new[] { CommunicationTokenScope.VoIP });

            // Retrieve the identity, token, and expiration date from the response
            var identity = identityAndTokenResponse.Value.User;
            var token = identityAndTokenResponse.Value.AccessToken.Token;
            var expiresOn = identityAndTokenResponse.Value.AccessToken.ExpiresOn;

            // Print the details to the screen
            Console.WriteLine($"\nCreated an identity with ID: {identity.Id}");
            Console.WriteLine($"\nIssued an access token with 'voip' scope that expires at {expiresOn}:");
            Console.WriteLine(token);
            Console.ReadLine();
        }

        static void test()
        {
            CommunicationTokenCredential token_credential = new CommunicationTokenCredential("<USER_ACCESS_TOKEN>");
            
        }
        
    }
}
