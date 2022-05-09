using Newtonsoft.Json;

namespace BlackJackV2.Business.Model;

public class Hand
{
    [JsonProperty]
    private List<Card> _cards = new();

    public IEnumerable<Card> GetCards()
    {
        return _cards.AsReadOnly();
    }

    public Hand() {}
    
    public Hand(params Card[] cards)
    {
        AddCards(cards);
    }

    public void AddCards(params Card[] cards)
    {
        foreach (var card in cards)
            _cards.Add(card);
    }

    public void Clear()
    {
        _cards.Clear();
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _cards)}]";
    }
}