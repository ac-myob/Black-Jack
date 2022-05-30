namespace BlackJackV2.Variables;

public static class Constants
{
    public const int CpuHitThreshold = 17;
    public const int BustThreshold = 21;
    public const string Yes = "y";
    public const string No = "n";
    public const string Quit = "q";
    public const string YesOrNoRegex = $"^{Yes}|{No}$";
    public const string HumanMoveOptions = $"{YesOrNoRegex}|^{Quit}$";
    public const string CpuName = "Dealer";
    public const string HumanName = "Contestant";
    public const string NonEmptyRegex = @"(.|\s)*\S(.|\s)*";
    public const int MinRounds = 1;
    public const int AceOffset = 10;
    public const int NumOfStartingCards = 2;
    public const string SavedGamesFilePath = "../../../../BlackJackV2/SavedGames/";
}
