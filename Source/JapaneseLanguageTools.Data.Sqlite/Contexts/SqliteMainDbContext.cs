using System;

using JapaneseLanguageTools.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace JapaneseLanguageTools.Data.Sqlite.Contexts;

public class SqliteMainDbContext : MainDbContext
{
    public SqliteMainDbContext()
        : base()
    {
        throw new NotImplementedException();
    }

    public SqliteMainDbContext(DbContextOptions contextOptions)
        : base(contextOptions)
    {
        throw new NotImplementedException();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
