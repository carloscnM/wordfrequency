
using System.Globalization;
using System.Text;

namespace Wordfrequency.APP.src
{
    public static class WordsTool
    {
        public static string RemoveAccent(string word)
        {
            if(string.IsNullOrEmpty(word))
                return string.Empty;

            StringBuilder NotAccentWord = new StringBuilder();   
            var arrayText = word.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {   
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                NotAccentWord.Append(letter);   
            } 

            return NotAccentWord.ToString();   
        }

        public static string RemoveSpecialCharacters(string word)
        {
            string treatedWord = word.Trim().Replace(",", string.Empty)
											.Replace(".", string.Empty)
											.Replace(";", string.Empty)
											.Replace("!", string.Empty)
											.Replace("#", string.Empty)
                                            .Replace("@", string.Empty);

            return treatedWord;                                
        }
    }

}