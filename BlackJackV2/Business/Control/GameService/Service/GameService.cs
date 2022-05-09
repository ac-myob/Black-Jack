using BlackJackV2.Business.Control.DeckFunctions;
using BlackJackV2.Business.Control.GameService.Deserializer;
using BlackJackV2.Business.Control.GameService.Serializer;
using BlackJackV2.Business.Control.Strategy;
using BlackJackV2.Business.Model;
using BlackJackV2.Business.View.IO;
using BlackJackV2.Variables;

namespace BlackJackV2.Business.Control.GameService.Service;

public class GameService : IGameService
{
    private readonly IWriter _writer;
    private readonly IReader _reader;
    private readonly Query _query;

    public GameService(IReader reader, IWriter writer)
    {
        _writer = writer;
        _reader = reader;
        _query = new Query(reader, writer);
    }

    private const string Extension = ".json";

    public GameState CreateNewGame()
    {
        var gameState = new GameState
        {
            Deck = new DeckFactory().GetDeck()
        };

        gameState.Deck.Shuffle();
        
        _writer.Write(Messages.GetNumRounds);
        gameState.TotalRounds = _query.GetInt(Constants.MinRounds, invalidInputMsg: Messages.InvalidInputRound);
        
        gameState.Players.AddPlayer(new Player(Constants.HumanName, new Hand(), new HumanStrategy(_reader, _writer)));
        gameState.Players.AddPlayer(new Player(Constants.CpuName, new Hand(), new CpuStrategy()));
        
        _SetPlayersHand(gameState);

        return gameState;
    }

    private static void _SetPlayersHand(GameState gameState)
    {
        foreach (var player in gameState.Players.GetPlayers())
            for (var _ = 0; _ < Constants.NumOfStartingCards; _++)
                player.Hand.AddCards(gameState.Deck.GetTopCard());
    }

    public void ResetGameRound(GameState gameState)
    {
        foreach (var player in gameState.Players.GetPlayers())
        {
            gameState.Deck.AddCards(player.Hand.GetCards().ToArray());
            player.Hand.Clear();
        }
        gameState.Deck.Shuffle();
        _SetPlayersHand(gameState);
        gameState.Players.CurrentPlayerIndex = 0;
        ++gameState.CurrentRound;
    }

    public void WriteGameToFile(IGameSerializer gameSerializer, GameState gameState)
    {
        _writer.Write(Messages.SaveGameFilename);
        gameSerializer.ToFile(gameState, _getFilePath());
    }
    
    public GameState ReadGameFromFile(IGameDeserializer gameDeserializer)
    {
        _writer.Write(Messages.LoadGameFilename);
        return gameDeserializer.FromFile( _getFilePath());
    }

    private string _getFilePath()
    {
        return Constants.SavedGamesFilePath + _query.GetString(Constants.NonEmptyRegex) + Extension;
    }
}