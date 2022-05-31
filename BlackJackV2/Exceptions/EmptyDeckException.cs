namespace BlackJackV2.Exceptions;

public class EmptyDeckException : InvalidOperationException
{
    public EmptyDeckException() : base("Cannot invoke function on empty deck.") {}
}
