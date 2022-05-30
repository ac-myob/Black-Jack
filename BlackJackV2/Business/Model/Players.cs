using Newtonsoft.Json;

namespace BlackJackV2.Business.Model;

public class Players
{
    [JsonProperty]
    private List<Player> _playersList = new();
    public int CurrentPlayerIndex { get; set; }

    public Players() {}

    public Players(params Player[] players)
    {
        foreach (var player in players)
            AddPlayer(player);
    }
    
    public IEnumerable<Player> GetPlayers()
    {
        return _playersList.AsReadOnly();
    }

    public void AddPlayer(Player player)
    {
        _playersList.Add(player);
    }

    public Player GetCurrentPlayer()
    {
        return _playersList[CurrentPlayerIndex];
    }

    public void SwitchToNextPlayer()
    {
        CurrentPlayerIndex = (CurrentPlayerIndex + 1) % _playersList.Count;
    }

    public Player? GetWinner()
    {
        return _playersList.Any(p => p.Points != _playersList.First().Points) ? _playersList.MaxBy(p => p.Points) : null;
    }
}
