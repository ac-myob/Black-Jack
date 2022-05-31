using BlackJackV2.Business.Model;

namespace BlackJackV2.Business.Control.Strategy;

public class DummyStrategy : IStrategy
{
    public bool ChoosesToHit(Hand hand)
    {
        return true;
    }
}
