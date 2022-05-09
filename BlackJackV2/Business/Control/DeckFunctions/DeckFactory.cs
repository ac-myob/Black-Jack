using BlackJackV2.Business.Model;
using BlackJackV2.Variables;

namespace BlackJackV2.Business.Control.DeckFunctions;

public class DeckFactory : IDeckFactory
{
    public Deck GetDeck()
    {
        var deck = new Deck();

        foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                deck.AddCards(new Card(suit, rank));

        return deck;
    }   
}