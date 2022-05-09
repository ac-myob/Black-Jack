using BlackJackV2.Business.Control.CardFunctions;
using BlackJackV2.Business.Model;
using BlackJackV2.Variables;

namespace BlackJackV2.Business.Control.HandFunctions;

public static class HandQuery
{
    public static int GetValue(Hand hand)
    {
        var handValue = hand.GetCards().Sum(CardQuery.GetCardValue);
        var numOfAces = hand.GetCards().Count(card => card.Rank == CardRank.Ace);

        while (handValue > Constants.BustThreshold && numOfAces > 0)
        {
            handValue -= Constants.AceOffset;
            --numOfAces;
        }

        return handValue;
    }

    public static bool IsBust(Hand hand)
    {
        return GetValue(hand) > Constants.BustThreshold;
    }
}