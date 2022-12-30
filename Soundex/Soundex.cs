using Soundex;
using Soundex.Models;
using System.Text;

namespace XSoundex;

public static class Soundex
{
	public static SoundexJson JsonSoundex { get; private set; }

	public static string ToSoundex(this string text)
	{
		var res = GenerateSoundex(text);

		return res;
	}

	public static bool HasTheSameSoundex(this string word1, string word2)
	{
		var resword1 = GenerateSoundex(word1);
		var resword2 = GenerateSoundex(word2);

		return resword1 == resword2;
	}

	public static string GenerateSoundex(string word)
	{
		JsonSoundex = (new JsonSoundex()).SoundexJson;

		if (JsonSoundex is null)
		{
			throw new InvalidDataException("Json File is not in Correct Format");
		}

		if (string.IsNullOrWhiteSpace(word))
		{
			return string.Empty;
		}

		var fLetter = MapTheFirstCharacter(word[0]);

		word = RemoveTheFirstCharacter(word);

		word = CleanUpTheVowlsCharacter(word);

		char[] Characters = word.ToCharArray();

		var buffer = new StringBuilder(4);
		buffer.Append(fLetter);

		foreach (var item in Characters)
		{
			int currCode = GetCharacterCode(item);
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

	private static int GetCharacterCode(char Characters)
	{
		if (JsonSoundex.CharacterCodes._1.FirstOrDefault(x => x == Characters) != '\0') { return 1; }
		if (JsonSoundex.CharacterCodes._2.FirstOrDefault(x => x == Characters) != '\0') { return 2; }
		if (JsonSoundex.CharacterCodes._3.FirstOrDefault(x => x == Characters) != '\0') { return 3; }
		if (JsonSoundex.CharacterCodes._4.FirstOrDefault(x => x == Characters) != '\0') { return 4; }
		if (JsonSoundex.CharacterCodes._5.FirstOrDefault(x => x == Characters) != '\0') { return 5; }
		if (JsonSoundex.CharacterCodes._6.FirstOrDefault(x => x == Characters) != '\0') { return 6; }

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

	static string CleanUpTheVowlsCharacter(string word)
	{

		word = word.RemoveWhitespace();

		foreach (var item in JsonSoundex.Vowls)
		{
			word = word.Replace(item, "");
		}

		return word;
	}

	private static string RemoveWhitespace(this string input)
	{
		return new string(input.ToCharArray()
			.Where(c => !char.IsWhiteSpace(c))
			.ToArray());
	}
}
