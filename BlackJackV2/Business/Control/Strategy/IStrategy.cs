using BlackJackV2.Business.Model;

namespace BlackJackV2.Business.Control.Strategy;

public interface IStrategy
{
    public bool ChoosesToHit(Hand hand);
}