using BlackJackV2.Business.Control.GameService.Deserializer;
using BlackJackV2.Business.Control.GameService.Serializer;
using BlackJackV2.Business.Model;

namespace BlackJackV2.Business.Control.GameService.Service;

public interface IGameService
{
    public GameState CreateNewGame();
    public void ResetGameRound(GameState gameState);
    public void WriteGameToFile(IGameSerializer gameSerializer, GameState gameState);
    public GameState ReadGameFromFile(IGameDeserializer gameDeserializer);
}