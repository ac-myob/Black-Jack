using BlackJackV2.Business.Model;

namespace BlackJackV2.Business.Control.GameService.Deserializer;

public interface IGameDeserializer
{
    public GameState FromFile(string filepath);
}
