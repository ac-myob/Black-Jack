using BlackJackV2.Business.Model;

namespace BlackJackV2.Business.Control.DeckFunctions;

public interface IDeckFactory
{
    public Deck GetDeck();
}