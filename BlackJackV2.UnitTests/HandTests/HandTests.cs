using System.Collections.Generic;
using System.Linq;
using BlackJackV2.Business.Control.CardFunctions;
using BlackJackV2.Business.Model;
using BlackJackV2.Variables;
using Xunit;

namespace BlackJackV2.Tests.HandTests;

public class HandTests
{
    [Theory]
    [MemberData(nameof(GetValueTestData))]
    public void GetValue_ReturnsOptimalHandValue(Card[] cards, int expectedHandValue)
    {
        var hand = new Hand(new BlackJackCardValue(), cards);

        var actualHandValue = hand.GetValue();
        
        Assert.Equal(expectedHandValue, actualHandValue);
    }

    [Theory]
    [MemberData(nameof(IsBustTestData))]
    public void IsBust_ReturnsTrueIfHandExceedsBustThreshold(Card[] cards, bool expected)
    {
        var hand = new Hand(new BlackJackCardValue(), cards);

        var actual = hand.IsBust();
        
        Assert.Equal(expected, actual);
    }
    
    
    [Theory]
    [MemberData(nameof(AddCardsTestData))]
    public void AddCards_AddsCardsToHand_WhenGivenCards(params Card[] cards)
    {
        var hand = new Hand(new DummyCardValue());

        hand.AddCards(cards);

        Assert.True(hand.GetCards().Zip(cards, (c1, c2) => c1.Equals(c2)).All(x => x));
    }

    [Fact]
    public void Clear_RemovesAllCardsInHand()
    {
        var hand = new Hand
            (
                new DummyCardValue(),
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Hearts, CardRank.King)
            );
        
        hand.Clear();

        Assert.Empty(hand.GetCards());
    }

    public static IEnumerable<object[]> AddCardsTestData()
    {
        yield return new object[]
        {
            new Card(CardSuit.Spades, CardRank.Ace)
        };

        yield return new object[]
        {
            new Card(CardSuit.Spades, CardRank.Ace),
            new Card(CardSuit.Hearts, CardRank.King)
        };
    }
    
    public static IEnumerable<object[]> GetValueTestData()
    {
        yield return new object[]
        {
            new[]
            {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Hearts, CardRank.King)
            },
            12

        };

        yield return new object[]
        {
            new[]
            {
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Hearts, CardRank.King)
            },
            21
        };
    }
    
    public static IEnumerable<object[]> IsBustTestData()
    {
        yield return new object[]
        {
            new[]
            {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Hearts, CardRank.King)
            },
            false

        };

        yield return new object[]
        {
            new[]
            {
                new Card(CardSuit.Spades, CardRank.Four),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Hearts, CardRank.King)
            },
            true
        };
    }
}
