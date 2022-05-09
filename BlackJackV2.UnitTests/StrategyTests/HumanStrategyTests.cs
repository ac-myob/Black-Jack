using System.Collections.Generic;
using BlackJackV2.Business.Control.Strategy;
using BlackJackV2.Business.Model;
using BlackJackV2.Business.View.IO;
using BlackJackV2.Variables;
using Xunit;

namespace BlackJackV2.Tests.StrategyTests;

public class HumanStrategyTests
{
    [Theory]
    [MemberData(nameof(QueryHitTestData))]
    public void QueryHit_ReturnsTrueIfHumanPlayerChoosesToHit_WhenGivenUserInput(string userInput, Hand hand, bool expectedBool)
    {
        var humanStrategy = new HumanStrategy(new MockReader(userInput), new DummyWriter());
        
        Assert.True(humanStrategy.ChoosesToHit(hand) == expectedBool);
    }
    
    public static IEnumerable<object[]> QueryHitTestData()
    {
        yield return new object[]
        {
            "y",
            new Hand
            (
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Ace)
            ),
            true
        };
      
        yield return new object[]
        {
            "n",
            new Hand
            (
            new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Ace)
            ),
            false
        };

        yield return new object[]
        {
            "y",
            new Hand
            (
                new Card(CardSuit.Spades, CardRank.Ten),
                new Card(CardSuit.Clubs, CardRank.Ten),
                new Card(CardSuit.Diamonds, CardRank.Ten)
            ),
            false
        };
        
        yield return new object[]
        {
            "n",
            new Hand
            (
                new Card(CardSuit.Spades, CardRank.Ten),
                new Card(CardSuit.Clubs, CardRank.Ten),
                new Card(CardSuit.Diamonds, CardRank.Ten)
            ),
            false
        };
    }
}