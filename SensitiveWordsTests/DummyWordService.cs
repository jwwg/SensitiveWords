using SensitiveWords.Model;

namespace SensitiveWordsTests
{
    public class DummyWordService : IWordService
    {
        public Task<List<SensitiveWord>> BadWords()
        {
            return Task.FromResult(DatabaseInitializer.
                SeedWords().
                Select(x => new SensitiveWord(x)).
                ToList());
        }

    }
}