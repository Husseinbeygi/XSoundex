using XSoundex;

namespace SoundexTest
{
    public class EnglishTests
    {
        [Theory]
        [InlineData("Robert", "R163")]
        [InlineData("Rupert", "R163")]
        [InlineData("Tymczak", "T522")]
        [InlineData("Honeyman", "H555")]
        [InlineData("improvement", "I516")]
        [InlineData("Rubin", "R150")]
        [InlineData("Ashcraft", "A226")]
        public void ShouldReturnProperSoundexCode(string word, string code)
        {
            Assert.Equal(word.ToSoundex(), code);
        }

    }
}
