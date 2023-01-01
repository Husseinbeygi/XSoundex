using System.Text;
using XSoundex.Models;

namespace XSoundex;

public class Soundex
{
    private readonly string? _culture;

    public SoundexJson JsonSoundex { get; private set; }

    public Soundex(string culture = "en-US")
    {
        _culture = culture;
    }

    public string GenerateSoundex(string word)
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(_culture);
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_culture);

        var culture = Thread.CurrentThread.CurrentCulture;

        JsonSoundex = (new JsonSoundex()).SoundexJson;

        if (JsonSoundex is null)
        {
            throw new InvalidDataException("Json File is not in Correct Format");
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
        if (JsonSoundex.CharacterCodes._1.FirstOrDefault(x => x == Characters) != null) { return 1; }
        if (JsonSoundex.CharacterCodes._2.FirstOrDefault(x => x == Characters) != null) { return 2; }
        if (JsonSoundex.CharacterCodes._3.FirstOrDefault(x => x == Characters) != null) { return 3; }
        if (JsonSoundex.CharacterCodes._4.FirstOrDefault(x => x == Characters) != null) { return 4; }
        if (JsonSoundex.CharacterCodes._5.FirstOrDefault(x => x == Characters) != null) { return 5; }
        if (JsonSoundex.CharacterCodes._6.FirstOrDefault(x => x == Characters) != null) { return 6; }

        return 0;
    }

    static char MapTheFirstCharacter(char v) => v switch
    {
        'ب' => 'B',
        'پ' => 'P',
        'ت' => 'T',
        'ط' => 'T',
        'س' => 'S',
        'ث' => 'S',
        'ص' => 'S',
        'ج' => 'J',
        'چ' => 'C',
        'ر' => 'R',
        'ه' => 'H',
        'ح' => 'H',
        'خ' => 'X',
        'د' => 'D',
        'ذ' => 'Z',
        'ظ' => 'Z',
        'ض' => 'Z',
        'ز' => 'Z',
        'ژ' => 'Z',
        'ش' => 'S',
        'غ' => 'G',
        'ک' => 'K',
        'گ' => 'G',
        'ق' => 'G',
        'ف' => 'F',
        'ل' => 'L',
        'م' => 'M',
        'ن' => 'N',
        'و' => 'V',
        'ع' => 'A',
        'ا' => 'A',
        'آ' => 'A',
        'أ' => 'A',
        'إ' => 'A',
        'ء' => 'A',
        'ی' => 'Y',
    };

    string CleanUpTheVowlsCharacter(string word)
    {

        word = RemoveWhitespace(word);

        foreach (var item in JsonSoundex.Vowls)
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
