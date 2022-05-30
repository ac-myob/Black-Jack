using System.Collections.Generic;
using System.Linq;
using BlackJackV2.Business.Control.DeckFunctions;
using BlackJackV2.Business.Model;
using BlackJackV2.Exceptions;
using BlackJackV2.Variables;
using Xunit;

namespace BlackJackV2.Tests;

public class DeckTests
{
    [Fact]
    public void GetTopCard_ReturnsAndRemovesTopCardFromDeck()
    {
        var expectedTopCard = new Card(CardSuit.Spades, CardRank.Ace);
        var deck = new MockDeckFactory(expectedTopCard).GetDeck();

        var actualTopCard = deck.GetTopCard();
        
        Assert.Equal(expectedTopCard, actualTopCard);
    }

    [Fact]
    public void GetTopCard_ThrowsEmptyDeckException_WhenDeckIsEmpty()
    {
        var deck = new MockDeckFactory().GetDeck();

        Assert.Throws<EmptyDeckException>(() => deck.GetTopCard());
    }

    [Theory]
    [MemberData(nameof(AddCardsTestData))]
    public void AddCards_AddsCardsToHand_WhenGivenCards(params Card[] cards)
    {
        var deck = new MockDeckFactory().GetDeck();

        deck.AddCards(cards);

        Assert.True(deck.GetCards().Zip(cards, (c1, c2) => c1.Equals(c2)).All(x=>x));
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
            new Card(rank: CardRank.King, suit: CardSuit.Hearts),
        };
    }
}