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

    public List<string> _1 { get; set; }

    public List<string> _2 { get; set; }

    public List<string> _3 { get; set; }

    public List<string> _4 { get; set; }

    public List<string> _5 { get; set; }

    public List<string> _6 { get; set; }
}

public class SoundexResourcesModel
{
    public SoundexResourcesModel()
    {
        CharacterCodes = new();
        Vowls = new();
        Maps = new();
    }
    public CharacterCodes CharacterCodes { get; set; }
    public List<string> Vowls { get; set; }
    public List<KeyValue> Maps { get; set; }

}

public class KeyValue
{
    public KeyValue(char key, char value)
    {
        Key = key;
        Value = value;
    }

    public char Key { get; set; }
    public char Value { get; set; }

}