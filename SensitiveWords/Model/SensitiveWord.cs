using System.ComponentModel.DataAnnotations;

namespace SensitiveWords.Model
{
    public class SensitiveWord
    {


        public SensitiveWord(string word)
        {
            Word = word;
        }

        [Key]
        public string Word { get; set; }
    }
}