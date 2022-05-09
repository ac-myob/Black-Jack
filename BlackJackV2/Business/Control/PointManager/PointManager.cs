using BlackJackV2.Business.Control.HandFunctions;
using BlackJackV2.Business.Model;

namespace BlackJackV2.Business.Control.PointManager;

public class PointManager : IPointManager
{
    public void UpdatePoints(Players players)
    {
        var humanPlayer = players.GetPlayers().First();
        var cpuPlayer = players.GetPlayers().Last();

        if (HandQuery.IsBust(humanPlayer.Hand))
            ++cpuPlayer.Points;
        else if (HandQuery.IsBust(cpuPlayer.Hand))
            ++humanPlayer.Points;
        else if (HandQuery.GetValue(humanPlayer.Hand) != HandQuery.GetValue(cpuPlayer.Hand))
            ++players.GetPlayers().MaxBy(p => HandQuery.GetValue(p.Hand))!.Points;
    }
}