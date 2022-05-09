using BlackJackV2.Business.Model;
using BlackJackV2.Variables;

namespace BlackJackV2.Business.Control.CardFunctions;

public static class CardQuery
{
    public static int GetCardValue(Card card)
    {
        Dictionary<CardRank, int> playingCardValues = new()
        {
            {CardRank.Two, 2},
            {CardRank.Three, 3},
            {CardRank.Four, 4},
            {CardRank.Five, 5},
            {CardRank.Six, 6},
            {CardRank.Seven, 7},
            {CardRank.Eight, 8},
            {CardRank.Nine, 9},
            {CardRank.Ten, 10},
            {CardRank.Jack, 10},
            {CardRank.Queen, 10},
            {CardRank.King, 10},
            {CardRank.Ace, 11}
        };
        
        return playingCardValues[card.Rank];
    }
}


