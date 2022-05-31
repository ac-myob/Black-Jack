using BlackJackV2.Business.Model;

namespace BlackJackV2.Business.Control.PointManager;

public class PointManager : IPointManager
{
    public void UpdatePoints(Players players)
    {
        var humanPlayer = players.GetPlayers().First();
        var cpuPlayer = players.GetPlayers().Last();

        if (humanPlayer.Hand.IsBust())
            ++cpuPlayer.Points;
        else if (cpuPlayer.Hand.IsBust())
            ++humanPlayer.Points;
        else if (humanPlayer.Hand.GetValue() != cpuPlayer.Hand.GetValue())
            ++players.GetPlayers().MaxBy(p => p.Hand.GetValue())!.Points;
    }
}
