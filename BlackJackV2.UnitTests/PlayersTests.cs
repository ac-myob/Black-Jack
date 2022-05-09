using System.Collections.Generic;
using System.Linq;
using BlackJackV2.Business.Control.Strategy;
using BlackJackV2.Business.Model;
using Xunit;

namespace BlackJackV2.Tests;

public class PlayersTests
{

    [Fact]
    public void AddPlayer_AddsAPlayerToPlayersList_WhenGivenAPlayer()
    {
        var player = new Player("Alice", new Hand(), new DummyStrategy());
        var players = new Players();

        players.AddPlayer(player);
        
        Assert.Equal(player, players.GetPlayers().First());
    }
    
    [Fact]
    public void GetCurrentPlayer_ReturnsCurrentPlayer()
    {
        var player1 = new Player("Alice", new Hand(), new DummyStrategy());
        var player2 = new Player("Bob", new Hand(), new DummyStrategy());
        var players = new Players();
        players.AddPlayer(player1);
        players.AddPlayer(player2);

        var actualCurrentPlayer = players.GetCurrentPlayer();
        
        Assert.Equal(player1, actualCurrentPlayer);
    }

    [Fact]
    public void SwitchToNextPlayer_SetsCurrentPlayerToNextPlayer()
    {
        var player1 = new Player("Alice", new Hand(), new DummyStrategy());
        var player2 = new Player("Bob", new Hand(), new DummyStrategy());
        var players = new Players();
        players.AddPlayer(player1);
        players.AddPlayer(player2);

        players.SwitchToNextPlayer();
        var actualCurrentPlayer = players.GetCurrentPlayer();
        
        Assert.Equal(player2, actualCurrentPlayer);
    }

    [Fact]
    public void GetWinner_ReturnsNull_WhenPlayersHaveTheSamePoints()
    {
        var player1 = new Player("Alice", new Hand(), new DummyStrategy());
        var player2 = new Player("Bob", new Hand(), new DummyStrategy());
        var players = new Players();
        players.AddPlayer(player1);
        players.AddPlayer(player2);
        
        Assert.Null(players.GetWinner());
    }

    [Theory]
    [MemberData(nameof(GetWinnerTestData))]
    public void GetWinner_ReturnsPlayerWithHighestPoints_WhenPlayersHaveDifferentPoints(Player[] playersArray, int winningPlayerIndex)
    {
        var players = new Players();
        foreach (var player in playersArray)
            players.AddPlayer(player);
        
        Assert.Equal(players.GetPlayers().ToArray()[winningPlayerIndex], players.GetWinner());
    }

    public static IEnumerable<object[]> GetWinnerTestData()
    {
        yield return new object[]
        {
            new Player[]
            {
                new ("Alice", new Hand(), new DummyStrategy()) { Points = 1 },
                new ("Bob", new Hand(), new DummyStrategy()) 
            },
            0
        };
        
        yield return new object[]
        {
            new Player[]
            {
                new ("Alice", new Hand(), new DummyStrategy()),
                new ("Bob", new Hand(), new DummyStrategy())  { Points = 1 }
            },
            1
        };
    }
}