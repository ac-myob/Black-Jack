using System.Text;
using BlackJackV2.Business.Model;
using BlackJackV2.Variables;

namespace BlackJackV2.Business.Control.GameInfo;

public class GameInfo : IGameInfo
{
    private readonly StringBuilder _stringBuilder = new();
    
    public string GetRoundInfo(GameState gameState)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append(Messages.GetRound(gameState.CurrentRound, gameState.TotalRounds));
        foreach (var player in gameState.Players.GetPlayers())
            _stringBuilder.Append($"{player.Name}: {player.Points}\n");
        _stringBuilder.Append(Messages.GetCurrentPlayer(gameState.Players.GetCurrentPlayer()));

        return _stringBuilder.ToString();
    }

    public string GetHandInfo(GameState gameState)
    {
        var currentPlayer = gameState.Players.GetCurrentPlayer();
        _stringBuilder.Clear();
        _stringBuilder.Append(Messages.GetPlayerHandValue(currentPlayer.Name, currentPlayer.Hand));
        _stringBuilder.Append(Messages.GetPlayerHand(currentPlayer.Hand));

        return _stringBuilder.ToString();
    }

    public string GetWinnerInfo(GameState gameState)
    {
        var winnerName = gameState.Players.GetWinner()?.Name;
        return winnerName != null ? Messages.WinOutcome(winnerName) : Messages.DrawOutcome;
    }
}
