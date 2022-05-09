using System.Collections.Generic;
using BlackJackV2.Business.Control.CardFunctions;
using BlackJackV2.Business.Control.Strategy;
using BlackJackV2.Business.Model;
using BlackJackV2.Variables;
using Xunit;

namespace BlackJackV2.Tests.StrategyTests;

public class CpuStrategyTests
{
    [Theory]
    [MemberData(nameof(QueryHitTestData))]
    public void QueryHit_ReturnsTrueIfCpuHandLessThanCpuBustThreshold_WhenGivenHand(Hand hand, bool expectedBool)
    {
        Assert.True(new CpuStrategy().ChoosesToHit(hand) == expectedBool);
    }

    public static IEnumerable<object[]> QueryHitTestData()
    {
        yield return new object[]
        {
            new Hand
            (
                new BlackJackCardValue(),
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Ace)
            ),
            true
        };

        yield return new object[]
        {
            new Hand
            (
                new BlackJackCardValue(),
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Five)
            ),
            false
        };

        yield return new object[]
        {
            new Hand
            (
                new BlackJackCardValue(),
                new Card(CardSuit.Spades, CardRank.Ten),
                new Card(CardSuit.Clubs, CardRank.Ten),
                new Card(CardSuit.Diamonds, CardRank.Ten)
            ),
            false
        };
    }
}