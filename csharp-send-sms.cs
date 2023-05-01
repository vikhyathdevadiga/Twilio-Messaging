using System.Text;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {

        const string ACCOUNT_SID = "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
        const string AUTH_TOKEN = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
        const string URL = "https://api.twilio.com/2010-04-01/Accounts/Twilio_Account_SID/Messages.json";

        using var client = new HttpClient();
        //HttpClient - https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 

        var authToken = Encoding.ASCII.GetBytes($"{ACCOUNT_SID}:{AUTH_TOKEN}");

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(authToken));

        var data = new[]
            {
                new KeyValuePair<string, string>("From", "+1XXXXXXXXXX"),
                new KeyValuePair<string, string>("To", "+1XXXXXXXXXX"),
                new KeyValuePair<string, string>("Body", "Hello"),
            };

        var result = await client.PostAsync(URL, new FormUrlEncodedContent(data));
        var content = await result.Content.ReadAsStringAsync();
        Console.WriteLine(content);
    }
}