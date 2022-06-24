using SensitiveWords.Model;

public class WordMasker : IWordMasker
{
    private readonly DatabaseContext _context;

    public WordMasker(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<string> Mask(string message)
    {
        var sortedBadWords = _context.BadWords.
            Select(x => x.Word).
            OrderByDescending(x => x.Length).
            ToList();

        var tmp = Enumerable.Range(1, sortedBadWords.First().Length)
            .Select(x => string.Concat(Enumerable.Repeat("*", x)))
            .ToArray();
        

        foreach (var badWord in sortedBadWords)
        {
            message = message.Replace(badWord, tmp[badWord.Length - 1], StringComparison.OrdinalIgnoreCase);
        }

        return message;
    }
}