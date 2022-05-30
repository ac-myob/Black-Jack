using System.Collections.Generic;
using BlackJackV2.Business.Control.CardFunctions;
using BlackJackV2.Business.Model;
using BlackJackV2.Variables;
using Xunit;

namespace BlackJackV2.Tests.HandTests;

public class HandDisplayTests
{
    [Theory]
    [MemberData(nameof(GetStringTestData))]
    public void GetString_ReturnsStringRepresentationOfHand_WhenGivenHand(Hand hand, string expectedString)
    {
        Assert.Equal(expectedString, hand.ToString());
    }

    public static IEnumerable<object[]> GetStringTestData()
    {
        yield return new object[]
        {
            new Hand
            (
                new BlackJackCardValue(),
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Ace)
            ),
            "[[Ace, ♠️], [Ace, ♣️]]"
        };

        yield return new object[]
        {
            new Hand
            (
                new BlackJackCardValue(),
                new Card(CardSuit.Hearts, CardRank.Seven),
                new Card(CardSuit.Clubs, CardRank.Nine)
            ),
            "[[Seven, ♥️], [Nine, ♣️]]"
        };
    }
}
