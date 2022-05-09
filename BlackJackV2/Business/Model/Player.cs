using BlackJackV2.Business.Control.Strategy;
using Newtonsoft.Json;

namespace BlackJackV2.Business.Model;

public class Player
{
    public string Name { get; }
    [JsonProperty]
    public Hand Hand { get; set; }
    [JsonProperty]
    public IStrategy Strategy { get; set; }
    public int Points { get; set; }
    public Player(string name, Hand hand, IStrategy strategy)
    {
        Name = name;
        Hand = hand;
        Strategy = strategy;
    }
}