using System.Collections.Generic;
using System.Linq;
using BlackJackV2.Business.Model;
using BlackJackV2.Variables;
using Xunit;

namespace BlackJackV2.Tests.HandTests;

public class HandTests
{
    [Theory]
    [MemberData(nameof(AddCardsTestData))]
    public void AddCards_AddsCardsToHand_WhenGivenCards(params Card[] cards)
    {
        var hand = new Hand();

        hand.AddCards(cards);

        Assert.True(hand.GetCards().Zip(cards, (c1, c2) => c1.Equals(c2)).All(x => x));
    }

    [Fact]
    public void Clear_RemovesAllCardsInHand()
    {
        var hand = new Hand
            (
                new Card(rank: CardRank.Ace, suit: CardSuit.Spades),
                new Card(rank: CardRank.King, suit: CardSuit.Hearts)
            );
        
        hand.Clear();

        Assert.Empty(hand.GetCards());
    }

    public static IEnumerable<object[]> AddCardsTestData()
    {
        yield return new object[]
        {
            new Card(rank: CardRank.Ace, suit: CardSuit.Spades)
        };

        yield return new object[]
        {
            new Card(rank: CardRank.Ace, suit: CardSuit.Spades),
            new Card(rank: CardRank.King, suit: CardSuit.Hearts)
        };
    }
}