using BlackJackV2.Business.Model;

namespace BlackJackV2.Business.Control.GameInfo;

public interface IGameInfo
{
    public string GetHandInfo(GameState gameState);

    public string GetRoundInfo(GameState gameState);

    public string GetWinnerInfo(GameState gameState);
}