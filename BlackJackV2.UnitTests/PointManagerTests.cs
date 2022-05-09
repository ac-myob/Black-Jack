using System.Collections.Generic;
using BlackJackV2.Business.Control.CardFunctions;
using BlackJackV2.Business.Control.PointManager;
using BlackJackV2.Business.Control.Strategy;
using BlackJackV2.Business.Model;
using BlackJackV2.Variables;
using Xunit;

namespace BlackJackV2.Tests;

public class PointManagerTests
{
    [Theory]
    [MemberData(nameof(UpdatePointsTestData))]
    public void UpdatePoints_CorrectlyUpdatesPlayersPoints_WhenGivenPlayers(Players players, string? expectedWinnerName)
    {
        new PointManager().UpdatePoints(players);

        Assert.Equal(expectedWinnerName, players.GetWinner()?.Name);
    }
    
    public static IEnumerable<object[]> UpdatePointsTestData()
    {
        yield return new object[]
        {
            new Players(
                new Player(
                    "Alice", 
                    new Hand(
                            new BlackJackCardValue(),
                            new Card(CardSuit.Diamonds, CardRank.Ten),
                            new Card(CardSuit.Clubs, CardRank.Ten),
                            new Card(CardSuit.Clubs, CardRank.Four)
                        ),
                    new DummyStrategy()
                    ),
                new Player(
                    "Bob", 
                    new Hand(
                        new BlackJackCardValue(),
                        new Card(CardSuit.Diamonds, CardRank.Seven),
                        new Card(CardSuit.Clubs, CardRank.King),
                        new Card(CardSuit.Clubs, CardRank.Jack)
                    ),
                    new DummyStrategy()
                )
            ),
            "Bob"
        };
        
        yield return new object[]
        {
            new Players(
                new Player(
                    "Alice", 
                    new Hand(
                        new BlackJackCardValue(),
                        new Card(CardSuit.Diamonds, CardRank.Ten),
                        new Card(CardSuit.Clubs, CardRank.Ten),
                        new Card(CardSuit.Clubs, CardRank.Four)
                    ),
                    new DummyStrategy()
                ),
                new Player(
                    "Bob", 
                    new Hand(
                        new BlackJackCardValue(),
                        new Card(CardSuit.Clubs, CardRank.King),
                        new Card(CardSuit.Clubs, CardRank.Jack)
                    ),
                    new DummyStrategy()
                )
            ),
            "Bob"
        };
        
        yield return new object[]
        {
            new Players(
                new Player(
                    "Alice", 
                    new Hand(
                        new BlackJackCardValue(),
                        new Card(CardSuit.Diamonds, CardRank.Ten),
                        new Card(CardSuit.Clubs, CardRank.Ten),
                        new Card(CardSuit.Clubs, CardRank.Ace)
                    ),
                    new DummyStrategy()
                ),
                new Player(
                    "Bob", 
                    new Hand(
                        new BlackJackCardValue(),
                        new Card(CardSuit.Clubs, CardRank.King),
                        new Card(CardSuit.Clubs, CardRank.Jack)
                    ),
                    new DummyStrategy()
                )
            ),
            "Alice"
        };
        
        yield return new object[]
        {
            new Players(
                new Player(
                    "Alice", 
                    new Hand(
                        new BlackJackCardValue(),
                        new Card(CardSuit.Diamonds, CardRank.Ten),
                        new Card(CardSuit.Clubs, CardRank.Ten)
                    ),
                    new DummyStrategy()
                ),
                new Player(
                    "Bob", 
                    new Hand(
                        new BlackJackCardValue(),
                        new Card(CardSuit.Clubs, CardRank.King),
                        new Card(CardSuit.Clubs, CardRank.Jack)
                    ),
                    new DummyStrategy()
                )
            ),
            null!
        };
        
        yield return new object[]
        {
            new Players(
                new Player(
                    "Alice", 
                    new Hand(
                        new BlackJackCardValue(),
                        new Card(CardSuit.Clubs, CardRank.Ten),
                        new Card(CardSuit.Clubs, CardRank.Four)
                    ),
                    new DummyStrategy()
                ),
                new Player(
                    "Bob", 
                    new Hand(
                        new BlackJackCardValue(),
                        new Card(CardSuit.Clubs, CardRank.King),
                        new Card(CardSuit.Clubs, CardRank.Jack)
                    ),
                    new DummyStrategy()
                )
            ),
            "Bob"
        };
    }
}