using Microsoft.EntityFrameworkCore;

namespace SensitiveWords.Model
{
    public class WordService : IWordService
    {
        private readonly DatabaseContext databaseContext;

        public WordService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<SensitiveWord>> BadWords()
        {
            return await databaseContext.BadWords.ToListAsync();
        }
    }
}
