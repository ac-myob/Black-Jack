using BlackJackV2.Business.Model;

namespace BlackJackV2.Business.Control.GameService.Serializer;

public interface IGameSerializer
{
    public void ToFile(GameState gameState, string filepath);
}
