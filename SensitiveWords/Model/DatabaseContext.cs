using Microsoft.EntityFrameworkCore;

namespace SensitiveWords.Model
{
    public class DatabaseContext : DbContext
    {

        public DbSet<SensitiveWord> BadWords { get; set; }


        public string DbPath { get; }

        public DatabaseContext() : base()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "words.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
