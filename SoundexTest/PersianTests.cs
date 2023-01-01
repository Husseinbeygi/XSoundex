using XSoundex;

namespace SoundexTest
{
    public class PersianTests
	{
		[Theory]
		[InlineData("گوسفند", "G215")]
		[InlineData("سلطان", "S435")]
		[InlineData("اکبر", "A216")]
		[InlineData("وزیر", "V260")]
		[InlineData("انگور", "A526")]
		[InlineData("زکیه", "Z200")]
		[InlineData("تلاوت", "T430")]
		[InlineData("ازدواج", "A232")]
		[InlineData("گران بها", "G651")]
		[InlineData("مسرور", "M266")]
		[InlineData("مشورت", "M630")]
		[InlineData("مطمئن", "M355")]
		[InlineData("پریچهر", "P626")]
		[InlineData("", "")]
		[InlineData(null, "")]
		public void ShouldReturnProperSoundexCode(string word,string code)
		{
			Assert.Equal(word.ToSoundex("fa-IR"), code);
		}

		[Theory]
		[InlineData("غول", "گول")]
		[InlineData("اصطکاک", "استکاک")]
		[InlineData("ذخیره", "زخیره")]
		[InlineData("حیاط", "حیات")]
		[InlineData("بهرام", "برنا")]
		public void ShouldReturnTrueIfTheWordsHaveTheSameSoundexCode(string word1, string word2)
		{
			Assert.True(word1.HasTheSameSoundex(word2, "fa-IR"));
		}
	}
}