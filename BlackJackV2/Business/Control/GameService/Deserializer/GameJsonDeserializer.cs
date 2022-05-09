using BlackJackV2.Business.Model;
using Newtonsoft.Json;

namespace BlackJackV2.Business.Control.GameService.Deserializer;

public class GameJsonDeserializer : IGameDeserializer
{
    public GameState FromFile(string filepath)
    {
        var jsonString = File.ReadAllText(filepath);
        
        return JsonConvert.DeserializeObject<GameState>(
            jsonString,
            new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            })!;
    }
}