using System.Collections.Generic;
using BlackJackV2.Business.Model;
using BlackJackV2.Variables;
using Xunit;

namespace BlackJackV2.Tests;

public class CardDisplayTests
{
    [Theory]
    [MemberData(nameof(GetStringTestData))]
    public void GetString_ReturnsStringRepresentationOfCard_WhenGivenACard(Card card, string expectedString)
    {
        Assert.Equal(expectedString, card.ToString());
    }
    
    public static IEnumerable<object[]> GetStringTestData()
    {
        yield return new object[]
        {
            new Card(CardSuit.Spades, CardRank.Ace),
            "[Ace, ♠️]"
        };
        
        yield return new object[]
        {
            new Card(CardSuit.Diamonds, CardRank.King),
            "[King, ♦️]"
        };

        yield return new object[]
        {
            new Card(CardSuit.Hearts, CardRank.Eight),
            "[Eight, ♥️]"
        };
    }
}