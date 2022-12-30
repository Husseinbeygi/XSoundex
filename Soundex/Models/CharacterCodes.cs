using System.Text.Json.Serialization;

namespace Soundex.Models;

public class CharacterCodes
{
	[JsonPropertyName("1")]
	public List<char> _1 { get; set; }

	[JsonPropertyName("2")]
	public List<char> _2 { get; set; }

	[JsonPropertyName("3")]
	public List<char> _3 { get; set; }

	[JsonPropertyName("4")]
	public List<char> _4 { get; set; }

	[JsonPropertyName("5")]
	public List<char> _5 { get; set; }

	[JsonPropertyName("6")]
	public List<char> _6 { get; set; }
}

public class SoundexJson
{
	[JsonPropertyName("CharacterCodes")]
	public CharacterCodes CharacterCodes { get; set; }

	[JsonPropertyName("Vowls")]
	public List<string> Vowls { get; set; }
}
