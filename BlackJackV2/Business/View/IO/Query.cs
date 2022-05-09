using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace BlackJackV2.Business.View.IO;

public class Query
{
    [JsonProperty]
    private readonly IReader _reader;
    [JsonProperty]
    private readonly IWriter _writer;
    public Query(IReader reader, IWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public int GetInt(int min = int.MinValue, int max = int.MaxValue, string? invalidInputMsg = null)
    {
        invalidInputMsg ??= $"Invalid input, number is not between {min} and {max}. Please try again: ";
        var readValue = _reader.Read();
        int res;
        while (!int.TryParse(readValue, out res) || !(min <= res && res < max))
        {
            _writer.Write(invalidInputMsg);
            readValue = _reader.Read();
        }

        return res;
    }

    public string GetString(string regex, string? invalidInputMsg = null)
    {
        invalidInputMsg ??= $"Invalid input, string does not match regex ({regex}). Please try again: ";
        var readValue = _reader.Read();
        while (!Regex.IsMatch(readValue, regex))
        {
            _writer.Write(invalidInputMsg); 
            readValue = _reader.Read();
        }

        return readValue;
    }
}