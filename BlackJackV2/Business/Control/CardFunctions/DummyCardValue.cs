using BlackJackV2.Business.Model;

namespace BlackJackV2.Business.Control.CardFunctions;

public class DummyCardValue : ICardValue
{
    public int GetValue(Card card)
    {
        return 0;
    }
}
