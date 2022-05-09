using BlackJackV2.Business.Control.HandFunctions;
using BlackJackV2.Business.Model;

namespace BlackJackV2.Variables;

public static class Messages
{
    public const string GetNumRounds = "Please enter number of rounds: ";
    public const string LoadGameFile = $"Would you like to load an existing game? [{Constants.Yes}/{Constants.No}]: ";
    public const string LoadGameFilename = "Please type in game filename to load from: ";
    public static readonly Func<string, Hand, string> GetPlayerHandValue = (playerName, playerHand) 
        => $"\n{playerName} is currently at {HandQuery.GetValue(playerHand)} {(HandQuery.IsBust(playerHand) ? "(bust)" : "")}\n";
    public static readonly Func<Hand, string> GetPlayerHand = playerHand 
        => $"with the hand {playerHand}\n";
    public static readonly Func<string, Card, string> GetDrawnCard = (playerName, playerCard) 
        => $"{playerName} draws {playerCard}\n";
    public static readonly Func<string, string> WinOutcome = playerName => $"\n{playerName} wins!";
    public const string DrawOutcome = "\nIt's a draw!";
    public const string GetHumanMove = $"Hit [{Constants.Yes}/{Constants.No}] or Quit [{Constants.Quit}]: ";
    public const string SaveGameFile = $"Would you like to save your game? [{Constants.Yes}/{Constants.No}]: ";
    public const string SaveGameFilename = "Please type in game filename to save to: ";
    public static readonly Func<int, int, string> GetRound = (currentRound, totalRounds) 
        => $"\nRound: {currentRound}/{totalRounds}\n";
    public static readonly Func<Player, string> GetCurrentPlayer = player => $"Current player turn: {player.Name}\n";
    public const string InvalidInputYesNo = $"Invalid input, please choose from the following options [{Constants.Yes}/{Constants.No}]: ";
    public static readonly string InvalidInputRound = $"Invalid input, round must be a number at least {Constants.MinRounds}. Please try again: ";
}