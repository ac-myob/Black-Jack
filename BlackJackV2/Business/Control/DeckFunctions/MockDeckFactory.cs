using BlackJackV2.Business.Model;

namespace BlackJackV2.Business.Control.DeckFunctions;

public class MockDeckFactory : IDeckFactory
{
    private readonly Deck _deck = new();

    public MockDeckFactory(params Card[] cards)
    {
        _deck.AddCards(cards);
    }
    
    public Deck GetDeck()
    {
        return _deck;
    }
}