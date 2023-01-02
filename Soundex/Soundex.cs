using System.Text;
using XSoundex.Models;

namespace XSoundex;

public class Soundex
{
    private readonly string? _culture;

    public SoundexResourcesModel SoundexResources { get; private set; }

    public Soundex(string culture = "en-US")
    {
        _culture = culture;
    }

    public string GenerateSoundex(string word)
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(_culture);
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_culture);

        var culture = Thread.CurrentThread.CurrentCulture;

        SoundexResources = (new SoundexResources()).XSResources;

        if (SoundexResources is null)
        {
            throw new InvalidDataException("Invalid Resource File");
        }

        if (string.IsNullOrWhiteSpace(word))
        {
            return string.Empty;
        }

        word = word.ToUpper();

        var fLetter = word[0];

        if (culture.TwoLetterISOLanguageName != "en")
        {
            fLetter = MapTheFirstCharacter(word[0]);
        }

        word = RemoveTheFirstCharacter(word);

        word = CleanUpTheVowlsCharacter(word);

        var Characters = word.ToList();

        var buffer = new StringBuilder(4);
        buffer.Append(fLetter);

        foreach (var item in Characters)
        {
            int currCode = GetCharacterCode(item.ToString());
            buffer.Append(currCode);
            if (buffer.Length == 4)
                break;
        }

        AddZeroToEndIfNeeded(buffer);

        return buffer.ToString();
    }

    private static void AddZeroToEndIfNeeded(StringBuilder buffer)
    {
        if (buffer.Length < 4)
            buffer.Append('0', (4 - buffer.Length));
    }

    private static string RemoveTheFirstCharacter(string word)
    {
        return word.Substring(1);
    }

    private int GetCharacterCode(string Characters)
    {
        if (SoundexResources.CharacterCodes._1.FirstOrDefault(x => x == Characters) != null) { return 1; }
        if (SoundexResources.CharacterCodes._2.FirstOrDefault(x => x == Characters) != null) { return 2; }
        if (SoundexResources.CharacterCodes._3.FirstOrDefault(x => x == Characters) != null) { return 3; }
        if (SoundexResources.CharacterCodes._4.FirstOrDefault(x => x == Characters) != null) { return 4; }
        if (SoundexResources.CharacterCodes._5.FirstOrDefault(x => x == Characters) != null) { return 5; }
        if (SoundexResources.CharacterCodes._6.FirstOrDefault(x => x == Characters) != null) { return 6; }

        return 0;
    }

    private char MapTheFirstCharacter(char v) 
    {
        var _value = SoundexResources.Maps.FirstOrDefault(x => x.Key == v);
        if (_value is null)
        {
            return v;
        }
        return _value.Value;
    }

    string CleanUpTheVowlsCharacter(string word)
    {

        word = RemoveWhitespace(word);

        foreach (var item in SoundexResources.Vowls)
        {
            word = word.Replace(item, "");
        }

        return word;
    }

    private static string RemoveWhitespace(string input)
    {
        return new string(input.ToCharArray()
            .Where(c => !char.IsWhiteSpace(c))
            .ToArray());
    }
}
