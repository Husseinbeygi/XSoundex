using XSoundex;

namespace ConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var a6 = "مروارید".ToSoundex();
			var a1 = "سلیمان".ToSoundex();
			var a2 = "سلم".ToSoundex();
			var a3 = "سام".ToSoundex();
			var a4 = "ساام".ToSoundex();
			var a5 = Soundex.GenerateSoundex("سلام");
		}
	}
}