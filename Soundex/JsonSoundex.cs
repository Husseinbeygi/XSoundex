using System.Text.Json;
using XSoundex.Models;
using XSoundex.Resources;

namespace XSoundex
{
    public class JsonSoundex
    {
        public JsonSoundex()
        {
            SoundexJson = new();
            GetResources();
        }

        public SoundexJson SoundexJson { get; private set; }

        private void GetResources()
        {
            SoundexJson.CharacterCodes._1 = SoundexRes._1.Split('/').ToList();
            SoundexJson.CharacterCodes._2 = SoundexRes._2.Split('/').ToList();
            SoundexJson.CharacterCodes._3 = SoundexRes._3.Split('/').ToList();
            SoundexJson.CharacterCodes._4 = SoundexRes._4.Split('/').ToList();
            SoundexJson.CharacterCodes._5 = SoundexRes._5.Split('/').ToList();
            SoundexJson.CharacterCodes._6 = SoundexRes._6.Split('/').ToList();
            SoundexJson.Vowls = SoundexRes.Vowls.Split('/').ToList();
        }


    }
}
