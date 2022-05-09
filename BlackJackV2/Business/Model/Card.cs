using BlackJackV2.Variables;

namespace BlackJackV2.Business.Model;

public class Card
{
    public CardSuit Suit { get; }
    public CardRank Rank { get; }

    public Card(CardSuit suit, CardRank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public bool Equals(Card card)
    {
        return Suit == card.Suit && Rank == card.Rank;
    }

    public override string ToString()
    {
        {
            var suitString = Suit switch
            {
                CardSuit.Spades => "♠️",
                CardSuit.Clubs => "♣️",
                CardSuit.Diamonds => "♦️",
                CardSuit.Hearts => "♥️",
                _ => null!
            };
        
            return $"[{Rank}, {suitString}]";
        }
    }
}