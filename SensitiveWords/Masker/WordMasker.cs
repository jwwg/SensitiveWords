using Microsoft.EntityFrameworkCore;
using SensitiveWords.Model;

public class WordMasker : IWordMasker
{
    private readonly IWordService _wordService;

    public WordMasker(IWordService wordService)
    {
        _wordService = wordService;
    }

    public async Task<string> Mask(string message)
    {
        var data = (await _wordService.BadWords());
        return ApplyMask(message, data);
    }

    public string ApplyMask(string message, List<SensitiveWord> data)
    {
        var sortedBadWords = data.
            Select(x => x.Word).
            OrderByDescending(x => x.Length);

        var masks = Enumerable.Range(1, sortedBadWords.First().Length)
            .Select(x => string.Concat(Enumerable.Repeat("*", x)))
            .ToArray();


        foreach (var badWord in sortedBadWords)
        {
            message = message.Replace(badWord, masks[badWord.Length - 1], StringComparison.OrdinalIgnoreCase);
        }

        return message;
    }
}