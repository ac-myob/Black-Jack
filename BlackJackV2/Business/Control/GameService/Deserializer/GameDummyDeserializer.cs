using BlackJackV2.Business.Model;

namespace BlackJackV2.Business.Control.GameService.Deserializer;

public class GameDummyDeserializer : IGameDeserializer
{
    public GameState FromFile(string filepath)
    {
        return new GameState();
    }
}