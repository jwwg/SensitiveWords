using SensitiveWords.Model;

public interface IWordService
{
    Task<List<SensitiveWord>> BadWords();
}