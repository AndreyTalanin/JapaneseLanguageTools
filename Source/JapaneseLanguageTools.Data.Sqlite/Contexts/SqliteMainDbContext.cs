using JapaneseLanguageTools.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace JapaneseLanguageTools.Data.Sqlite.Contexts;

public class SqliteMainDbContext : MainDbContext
{
    public SqliteMainDbContext()
        : base()
    {
    }

    public SqliteMainDbContext(DbContextOptions contextOptions)
        : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
