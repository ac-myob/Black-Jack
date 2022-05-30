using BlackJackV2.Business.Control.GameInfo;
using BlackJackV2.Business.Control.GameService.Deserializer;
using BlackJackV2.Business.Control.GameService.Serializer;
using BlackJackV2.Business.Control.PointManager;
using BlackJackV2.Business.Model;
using BlackJackV2.Business.View.IO;
using BlackJackV2.Exceptions;
using BlackJackV2.Variables;

namespace BlackJackV2.Business.Control;

public class GameEngine
{
    private GameState _currentGameState = new();
    private readonly GameService.Service.GameService _gameService;
    private readonly IWriter _writer;
    private readonly Query _query;
    private readonly IPointManager _pointManager = new PointManager.PointManager();
    private readonly IGameInfo _gameInfo = new GameInfo.GameInfo();

    public GameEngine(IReader reader, IWriter writer)
    {
        _gameService = new GameService.Service.GameService(reader, writer);
        _writer = writer;
        _query = new Query(reader, writer);

    }
    
    public GameState Run()
    {
        _setUpGame();
        while (_currentGameState.CurrentRound <= _currentGameState.TotalRounds)
        {
            _writer.Write(_gameInfo.GetRoundInfo(_currentGameState));
            _playRound();
            _pointManager.UpdatePoints(_currentGameState.Players);
            _gameService.ResetGameRound(_currentGameState);
        }
        _writer.Write(_gameInfo.GetWinnerInfo(_currentGameState));
        
        return _currentGameState;
    }

    private void _setUpGame()
    {
        _writer.Write(Messages.LoadGameFile);
        _currentGameState = _query.GetString(Constants.YesOrNoRegex, Messages.InvalidInputYesNo) == Constants.No ? 
            _gameService.CreateNewGame() : 
            _gameService.ReadGameFromFile(new GameJsonDeserializer());
    }

    private void _playRound()
    {
        for (var _ = 0; _ < _currentGameState.Players.GetPlayers().Count(); _++)
        {
            var currentPlayer = _currentGameState.Players.GetCurrentPlayer();
            var hit = false;
            do
            {
                _writer.Write(_gameInfo.GetHandInfo(_currentGameState));
                try
                {
                    hit = currentPlayer.Strategy.ChoosesToHit(currentPlayer.Hand);
                    if (!hit) continue;
                    var drawnCard = _currentGameState.Deck.GetTopCard();
                    currentPlayer.Hand.AddCards(drawnCard);
                    _writer.Write(Messages.GetDrawnCard(currentPlayer.Name, drawnCard));
                }
                catch (PlayerQuitException)
                {
                    _saveGame();
                }
            } while (hit);
            
            if (currentPlayer.Hand.IsBust()) return;

            _currentGameState.Players.SwitchToNextPlayer();
        }
    }

    private void _saveGame()
    {
        _writer.Write(Messages.SaveGameFile);
        if (_query.GetString(Constants.YesOrNoRegex) == Constants.Yes)
            _gameService.WriteGameToFile(new GameJsonSerializer(), _currentGameState);
        Environment.Exit(0);
    }
}
