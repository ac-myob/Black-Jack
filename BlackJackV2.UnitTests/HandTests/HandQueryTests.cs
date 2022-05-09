using System.Collections.Generic;
using BlackJackV2.Business.Control.HandFunctions;
using BlackJackV2.Business.Model;
using BlackJackV2.Variables;
using Xunit;

namespace BlackJackV2.Tests.HandTests;

public class HandQueryTests
{
    [Fact]
    public void GetValue_ReturnsZero_WhenGivenCardsIsEmpty()
    {
        var hand = new Hand();

        Assert.Equal(0, HandQuery.GetValue(hand));
    }

    [Theory]
    [MemberData(nameof(OptimalHandTestData))]
    public void GetValue_ReturnsOptimalHandValue_WhenGivenCards(Hand hand, int expectedValue)
    {
        var actualValue = HandQuery.GetValue(hand);

        Assert.Equal(expectedValue, actualValue);
    }

    public static IEnumerable<object[]> OptimalHandTestData()
    {
        yield return new object[]
        {
            new Hand
            (
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Ace)
            ),
            12
        };

        yield return new object[]
        {
            new Hand
            (
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Five)
            ),
            16
        };
    }
}