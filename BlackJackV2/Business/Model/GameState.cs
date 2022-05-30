namespace BlackJackV2.Business.Model;

public class GameState
{
    public Deck Deck { get; set; } = null!;
    public Players Players { get; set; } = new();
    public int CurrentRound { get; set; } = 1;
    public int TotalRounds { get; set; }
}
