using BlackJackV2.Business.Model;
using Newtonsoft.Json;

namespace BlackJackV2.Business.Control.GameService.Serializer;

public class GameJsonSerializer : IGameSerializer
{
    public void ToFile(GameState gameState, string filepath)
    {
        var jsonString = JsonConvert.SerializeObject(
            gameState, 
            Formatting.Indented,
            new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        
        File.WriteAllText(filepath, jsonString);
    }
}