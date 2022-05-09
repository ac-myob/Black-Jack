using BlackJackV2.Business.Model;
using BlackJackV2.Business.View.IO;
using BlackJackV2.Exceptions;
using BlackJackV2.Variables;
using Newtonsoft.Json;

namespace BlackJackV2.Business.Control.Strategy;

public class HumanStrategy : IStrategy
{
    [JsonProperty]
    private readonly IReader _reader;
    [JsonProperty]
    private readonly IWriter _writer;
    [JsonProperty]
    private readonly Query _query;
    
    public HumanStrategy(IReader reader, IWriter writer)
    {
        _reader = reader;
        _writer = writer;
        _query = new Query(reader, writer);
    }

    public bool ChoosesToHit(Hand hand)
    {
        if (hand.GetValue() > Constants.BustThreshold) 
            return false;
        
        _writer.Write(Messages.GetHumanMove);
        return _query.GetString(Constants.HumanMoveOptions) switch
        {
            Constants.Quit => throw new PlayerQuitException(),
            Constants.Yes => true,
            _ => false
        };
    }
}