using System.Text;

namespace DebercBackend.IntegrationTests.Utilities;

public static class GameUtility
{    
    public const string ApiUrl = "/api/v1/games";
    private const string GameJsonPayload = "./Data/Game.json";

    public static async Task<string> CreateGame(HttpClient client)
    {
        string jsonContent = await File.ReadAllTextAsync(GameJsonPayload);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(ApiUrl, content);

        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        
        return responseBody;
    }
}