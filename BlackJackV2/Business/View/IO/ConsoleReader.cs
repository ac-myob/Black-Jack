namespace BlackJackV2.Business.View.IO;

public class ConsoleReader : IReader
{
    public string Read()
    {
        return Console.ReadLine() ?? string.Empty;
    }
}