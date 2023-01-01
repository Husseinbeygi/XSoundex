using System.Text.Json.Serialization;

namespace XSoundex.Models;

public class CharacterCodes
{
    public CharacterCodes()
    {
        _1 = new();
        _2 = new();
        _3 = new();
        _4 = new();
        _5 = new();
        _6 = new();
    }

    [JsonPropertyName("1")]
    public List<string> _1 { get; set; }

    [JsonPropertyName("2")]
    public List<string> _2 { get; set; }

    [JsonPropertyName("3")]
    public List<string> _3 { get; set; }

    [JsonPropertyName("4")]
    public List<string> _4 { get; set; }

    [JsonPropertyName("5")]
    public List<string> _5 { get; set; }

    [JsonPropertyName("6")]
    public List<string> _6 { get; set; }
}

public class SoundexJson
{
    public SoundexJson()
    {
        CharacterCodes = new();
        Vowls = new();
    }

    [JsonPropertyName("CharacterCodes")]
    public CharacterCodes CharacterCodes { get; set; }

    [JsonPropertyName("Vowls")]
    public List<string> Vowls { get; set; }
}
