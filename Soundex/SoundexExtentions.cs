namespace XSoundex;

public static class SoundexExtentions
{
    /// <summary>
    /// For calculation of Soundex
    /// </summary>
    /// <param name="text">Text</param>
    /// <param name="culture">Prefer Culture, if not specified, it uses the current culture</param>
    /// <returns></returns>
    public static string ToSoundex(this string text,string culture = null)
    {
        culture ??= Thread.CurrentThread.CurrentCulture.Name;

        var s = new Soundex(culture);

        var res = s.GenerateSoundex(text);

        return res;
    }

    /// <summary>
    /// For compring Soundex of two words
    /// </summary>
    /// <param name="text">Text</param>
    /// <param name="culture">Prefer Culture, if not specified, it uses the current culture</param>
    /// <returns></returns>
    public static bool HasTheSameSoundex(this string word1, string word2, string culture = null)
    {
        culture ??= Thread.CurrentThread.CurrentCulture.Name;

        var s = new Soundex(culture);

        var resword1 = s.GenerateSoundex(word1);
        var resword2 = s.GenerateSoundex(word2);

        return resword1 == resword2;
    }

}
