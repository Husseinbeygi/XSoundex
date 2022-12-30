using System.Text;

namespace XSoundex;

public static class Soundex
{
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

	private static int GetCharacterCode(char Characters) => Characters switch
	{
		'ف' or 'ب' or 'پ' => 1,

		'ج' or 'ز' or 'س' or 'ص' or 'ظ' or
		'ق' or 'ك' or 'گ' or 'ث' or 'ذ' or
		'ض' or 'خ' or 'چ' or 'ک' => 2,

		'د' or 'ت' or 'ط' => 3,

		'ل' => 4,

		'م' or 'ن' => 5,

		'ر' => 6,

		_ => 0,
	};

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

		var vowls = new HashSet<string>();

		vowls.Add("ا");
		vowls.Add("أ");
		vowls.Add("إ");
		vowls.Add("آ");
		vowls.Add("ح");
		vowls.Add("خ");
		vowls.Add("ه");
		vowls.Add("ع");
		vowls.Add("غ");
		vowls.Add("ش");
		vowls.Add("و");
		vowls.Add("ي");
		vowls.Add("ی");
		vowls.Add("و");
		vowls.Add("ه");
		vowls.Add("ا");
		vowls.Add("ئ");

		foreach (var item in vowls)
		{
			word = word.Replace(item, "");
		}

		//switch (word[0])
		//{
		//	case 'ا':
		//	case 'أ':
		//	case 'إ':
		//	case 'آ':
		//		{
		//			word = word.Substring(1, word.Length - 1);
		//		}
		//		break;

		//}

		return word;
	}

	private static string RemoveWhitespace(this string input)
	{
		return new string(input.ToCharArray()
			.Where(c => !char.IsWhiteSpace(c))
			.ToArray());
	}
}
