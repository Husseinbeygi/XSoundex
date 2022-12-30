using System.Text.Json;

namespace Soundex
{
	public class JsonSoundex
	{
		public JsonSoundex()
		{
			SoundexJson = new();
			ReadJson();
		}

		public Models.SoundexJson SoundexJson { get; private set; }

		private void ReadJson()
		{
			if (SoundexJson.CharacterCodes != null)
			{
				return;
			}

			using StreamReader r = new("soundex.fa-IR.json");

			string json = r.ReadToEnd();

			if (!string.IsNullOrWhiteSpace(json))
			{
				SoundexJson = JsonSerializer.Deserialize<Models.SoundexJson>(json);
			}
			else
			{
				throw new InvalidDataException("Json File is not in Correct Format");
			}
		}


	}
}
