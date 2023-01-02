using XSoundex.Models;
using XSoundex.Resources;

namespace XSoundex
{
    public class SoundexResources
    {
        public SoundexResources()
        {
            XSResources = new();
            GetResources();
        }

        public SoundexResourcesModel XSResources { get; private set; }

        private void GetResources()
        {
            XSResources.CharacterCodes._1 = SoundexRes._1.Split('/').ToList();
            XSResources.CharacterCodes._2 = SoundexRes._2.Split('/').ToList();
            XSResources.CharacterCodes._3 = SoundexRes._3.Split('/').ToList();
            XSResources.CharacterCodes._4 = SoundexRes._4.Split('/').ToList();
            XSResources.CharacterCodes._5 = SoundexRes._5.Split('/').ToList();
            XSResources.CharacterCodes._6 = SoundexRes._6.Split('/').ToList();
            XSResources.Vowls = SoundexRes.Vowls.Split('/').ToList();

            if (Thread.CurrentThread.
                CurrentUICulture.TwoLetterISOLanguageName != "en")
            {
                var _maps = SoundexRes.Maps.Split("/").ToList();

                foreach (var item in _maps)
                {
                    if (string.IsNullOrWhiteSpace(item))
                    {
                        continue;
                    }
                    var _v = item.Split(":");
                    var _v1 = _v[1].ToCharArray()[0];
                    var _v0 = _v[0].ToCharArray()[0];
                    XSResources.Maps.Add(new KeyValue(_v0, _v1));
                }
            }


        }


    }
}
