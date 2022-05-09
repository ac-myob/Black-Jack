using BlackJackV2.Business.Model;

namespace BlackJackV2.Business.Control.CardFunctions;

public interface ICardValue
{
    public int GetValue(Card card);
}