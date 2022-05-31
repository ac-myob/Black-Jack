using BlackJackV2.Business.Model;
using BlackJackV2.Variables;

namespace BlackJackV2.Business.Control.Strategy;

public class ComputerStrategy : IStrategy
{
    public bool ChoosesToHit(Hand hand)
    {
        return hand.GetValue() < Constants.ComputerHitThreshold;
    }
}
