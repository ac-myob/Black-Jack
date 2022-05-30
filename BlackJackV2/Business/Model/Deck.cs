using BlackJackV2.Exceptions;
using Newtonsoft.Json;

namespace BlackJackV2.Business.Model;

public class Deck
{
    [JsonProperty]
    private List<Card> _cards = new();

    public IEnumerable<Card> GetCards()
    {
        return _cards.AsReadOnly();
    }

    public void Shuffle()
    {
        _cards = _cards.OrderBy(_ => new Random().Next()).ToList();
    }

    public Card GetTopCard()
    {
        if (_cards.Count < 1)
            throw new EmptyDeckException();
        
        return _cards[^1];
    }

    public void RemoveTopCard()
    {
        var topCardIndex = _cards.Count - 1;
        _cards.RemoveAt(topCardIndex);
    }
    
    public void AddCards(params Card[] cards)
    {
        foreach (var card in cards)
            _cards.Add(card);
    }
}
