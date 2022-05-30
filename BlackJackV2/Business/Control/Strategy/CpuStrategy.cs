using BlackJackV2.Business.Model;
using BlackJackV2.Variables;

namespace BlackJackV2.Business.Control.Strategy;

public class CpuStrategy : IStrategy
{
    public bool ChoosesToHit(Hand hand)
    {
        return hand.GetValue() < Constants.CpuHitThreshold;
    }
}
