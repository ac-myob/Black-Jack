using BlackJackV2.Business.Control.CardFunctions;
using BlackJackV2.Variables;
using Newtonsoft.Json;

namespace BlackJackV2.Business.Model;

public class Hand
{
    [JsonProperty]
    private readonly ICardValue _cardValue;

    [JsonProperty]
    private List<Card> _cards = new();

    public IEnumerable<Card> GetCards()
    {
        return _cards.AsReadOnly();
    }

    [JsonConstructor]
    public Hand(ICardValue cardValue)
    {
        _cardValue = cardValue;
    }
    
    public Hand(ICardValue cardValue, params Card[] cards)
    {
        _cardValue = cardValue;
        AddCards(cards);
    }

    public int GetValue()
    {
        var handValue = _cards.Sum(_cardValue.GetValue);
        var numOfAces = _cards.Count(card => card.Rank == CardRank.Ace);

        while (handValue > Constants.BustThreshold && numOfAces > 0)
        {
            handValue -= Constants.AceOffset;
            --numOfAces;
        }

        return handValue;
    }

    public bool IsBust()
    {
        return GetValue() > Constants.BustThreshold;
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