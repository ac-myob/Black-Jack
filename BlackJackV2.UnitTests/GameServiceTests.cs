using System;
using System.Linq;
using BlackJackV2.Business.Control.CardFunctions;
using BlackJackV2.Business.Control.DeckFunctions;
using BlackJackV2.Business.Control.GameService.Service;
using BlackJackV2.Business.Control.Strategy;
using BlackJackV2.Business.Model;
using BlackJackV2.Business.View.IO;
using Xunit;
using Constants = BlackJackV2.Variables.Constants;

namespace BlackJackV2.Tests;

public class GameServiceTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    public void CreateNewGame_ReturnsGameStateWithStartingValues(int rounds)
    {
        var gameService = new GameService(new MockReader(rounds), new DummyWriter());

        var newGameState = gameService.CreateNewGame();
        
        Assert.Equal(rounds, newGameState.TotalRounds);
    }
    
    [Fact]
    public void ResetGame_ReturnsGameStateWithInitialStartingValues_WhenGivenOldGameState()
    {
        var gameService = new GameService(new MockReader(), new DummyWriter());
        var oldGame = _resetGameTestData();
        var oldGameRound = oldGame.CurrentRound;
    
        gameService.ResetGameRound(oldGame);
    
        var handIsReset = oldGame.Players.GetPlayers().All(p => p.Hand.GetCards().Count() == Constants.NumOfStartingCards);
        var deckIsReset = oldGame.Deck.GetCards().Count() == 48;
        var roundIncremented = oldGame.CurrentRound == oldGameRound + 1;
        
        Assert.True(handIsReset && deckIsReset && roundIncremented);
    }
    
    private static GameState _resetGameTestData()
    {
        var rng = new Random();
        var deck = new DeckFactory().GetDeck();
        var players = new Players();
        var player1 = new Player("Alice", new Hand(new BlackJackCardValue()), new DummyStrategy());
        var player2 = new Player("Bob", new Hand(new BlackJackCardValue()), new DummyStrategy());
        var totalRounds = rng.Next(1, 101);
        var currentRound = rng.Next(1, totalRounds + 1);
    
        foreach (var player in new[] {player1, player2})
        {
            players.AddPlayer(player);
            for (var i = 2; i <= rng.Next(2,6); i++)
                player.Hand.AddCards(deck.GetTopCard());
        }
        
        return new GameState
        {
            Deck = deck,
            Players = players,
            CurrentRound = currentRound,
            TotalRounds = totalRounds
        };
    }
}
