using System;

using JapaneseLanguageTools.Data.Contexts;
using JapaneseLanguageTools.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JapaneseLanguageTools.Data.Sqlite.Contexts;

public class SqliteMainDbContext : MainDbContext
{
    private const string c_noCaseCollationSql = "NOCASE";
    private const string c_currentTimestampUtcSql = "STRFTIME('%F %T+00:00', 'now')";

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
        modelBuilder.UseCollation(c_noCaseCollationSql);

        modelBuilder.Entity<Tag>(entityBuilder =>
        {
            entityBuilder.HasKey(entity => entity.Id);

            entityBuilder.HasAlternateKey(entity => entity.Caption);

            entityBuilder.Property(entity => entity.CreatedOn).HasDefaultValueSql(c_currentTimestampUtcSql);
            entityBuilder.Property(entity => entity.UpdatedOn).HasDefaultValueSql(c_currentTimestampUtcSql);

            entityBuilder.ToTable("Tag", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint("CK_Tag_Caption_NotEmpty", "LENGTH(TRIM(\"Caption\")) > 0");
                tableBuilder.HasCheckConstraint("CK_Tag_Caption_MaxLength", "LENGTH(TRIM(\"Caption\")) <= 256");
                tableBuilder.HasCheckConstraint("CK_Tag_PlaceholderMarker_NullOrNotEmpty", "\"PlaceholderMarker\" IS NULL OR LENGTH(TRIM(\"PlaceholderMarker\")) > 0");
                tableBuilder.HasCheckConstraint("CK_Tag_PlaceholderMarker_NullOrMaxLength", "\"PlaceholderMarker\" IS NULL OR LENGTH(TRIM(\"PlaceholderMarker\")) <= 2048");
            });
        });

        modelBuilder.Entity<Character>(entityBuilder =>
        {
            entityBuilder.HasKey(entity => entity.Id);

            entityBuilder.HasOne(entity => entity.CharacterGroup)
                .WithMany(entity => entity.Characters)
                .HasForeignKey(entity => entity.CharacterGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasIndex(entity => entity.CharacterGroupId)
                .HasDatabaseName("IX_Character_CharacterGroupId");

            entityBuilder.Property(entity => entity.CreatedOn).HasDefaultValueSql(c_currentTimestampUtcSql);
            entityBuilder.Property(entity => entity.UpdatedOn).HasDefaultValueSql(c_currentTimestampUtcSql);

            entityBuilder.ToTable("Character", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint("CK_Character_Symbol_NotEmpty", "LENGTH(TRIM(\"Symbol\")) > 0");
                tableBuilder.HasCheckConstraint("CK_Character_Symbol_MaxLength", "LENGTH(TRIM(\"Symbol\")) <= 16");
                tableBuilder.HasCheckConstraint("CK_Character_Pronunciation_NullOrNotEmpty", "\"Pronunciation\" IS NULL OR LENGTH(TRIM(\"Pronunciation\")) > 0");
                tableBuilder.HasCheckConstraint("CK_Character_Pronunciation_NullOrMaxLength", "\"Pronunciation\" IS NULL OR LENGTH(TRIM(\"Pronunciation\")) <= 32");
                tableBuilder.HasCheckConstraint("CK_Character_Syllable_NullOrNotEmpty", "\"Syllable\" IS NULL OR LENGTH(TRIM(\"Syllable\")) > 0");
                tableBuilder.HasCheckConstraint("CK_Character_Syllable_NullOrMaxLength", "\"Syllable\" IS NULL OR LENGTH(TRIM(\"Syllable\")) <= 32");
                tableBuilder.HasCheckConstraint("CK_Character_Onyomi_NullOrNotEmpty", "\"Onyomi\" IS NULL OR LENGTH(TRIM(\"Onyomi\")) > 0");
                tableBuilder.HasCheckConstraint("CK_Character_Onyomi_NullOrMaxLength", "\"Onyomi\" IS NULL OR LENGTH(TRIM(\"Onyomi\")) <= 256");
                tableBuilder.HasCheckConstraint("CK_Character_Kunyomi_NullOrNotEmpty", "\"Kunyomi\" IS NULL OR LENGTH(TRIM(\"Kunyomi\")) > 0");
                tableBuilder.HasCheckConstraint("CK_Character_Kunyomi_NullOrMaxLength", "\"Kunyomi\" IS NULL OR LENGTH(TRIM(\"Kunyomi\")) <= 256");
                tableBuilder.HasCheckConstraint("CK_Character_Meaning_NullOrNotEmpty", "\"Meaning\" IS NULL OR LENGTH(TRIM(\"Meaning\")) > 0");
                tableBuilder.HasCheckConstraint("CK_Character_Meaning_NullOrMaxLength", "\"Meaning\" IS NULL OR LENGTH(TRIM(\"Meaning\")) <= 512");
            });
        });

        modelBuilder.Entity<CharacterGroup>(entityBuilder =>
        {
            entityBuilder.HasKey(entity => entity.Id);

            entityBuilder.HasAlternateKey(entity => entity.Caption);

            entityBuilder.Property(entity => entity.CreatedOn).HasDefaultValueSql(c_currentTimestampUtcSql);
            entityBuilder.Property(entity => entity.UpdatedOn).HasDefaultValueSql(c_currentTimestampUtcSql);

            entityBuilder.ToTable("CharacterGroup", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint("CK_CharacterGroup_Caption_NotEmpty", "LENGTH(TRIM(\"Caption\")) > 0");
                tableBuilder.HasCheckConstraint("CK_CharacterGroup_Caption_MaxLength", "LENGTH(TRIM(\"Caption\")) <= 256");
                tableBuilder.HasCheckConstraint("CK_CharacterGroup_Comment_NullOrNotEmpty", "\"Comment\" IS NULL OR LENGTH(TRIM(\"Comment\")) > 0");
                tableBuilder.HasCheckConstraint("CK_CharacterGroup_Comment_NullOrMaxLength", "\"Comment\" IS NULL OR LENGTH(TRIM(\"Comment\")) <= 2048");
            });
        });

        modelBuilder.Entity<CharacterTag>(entityBuilder =>
        {
            entityBuilder.HasKey(entity => new { entity.CharacterId, entity.TagId });

            entityBuilder.HasOne(entity => entity.Character)
                .WithMany(entity => entity.CharacterTags)
                .HasForeignKey(entity => entity.CharacterId)
                .OnDelete(DeleteBehavior.Cascade);
            entityBuilder.HasOne(entity => entity.Tag)
                .WithMany()
                .HasForeignKey(entity => entity.TagId)
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasIndex(entity => entity.CharacterId)
                .HasDatabaseName("IX_CharacterTag_CharacterId");
            entityBuilder.HasIndex(entity => entity.TagId)
                .HasDatabaseName("IX_CharacterTag_TagId");

            entityBuilder.ToTable("CharacterTag", tableBuilder =>
            {
            });
        });

        modelBuilder.Entity<Word>(entityBuilder =>
        {
            entityBuilder.HasKey(entity => entity.Id);

            entityBuilder.HasOne(entity => entity.WordGroup)
                .WithMany(entity => entity.Words)
                .HasForeignKey(entity => entity.WordGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasIndex(entity => entity.WordGroupId)
                .HasDatabaseName("IX_Word_WordGroupId");

            entityBuilder.Property(entity => entity.CreatedOn).HasDefaultValueSql(c_currentTimestampUtcSql);
            entityBuilder.Property(entity => entity.UpdatedOn).HasDefaultValueSql(c_currentTimestampUtcSql);

            entityBuilder.ToTable("Word", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint("CK_Word_Characters_NotEmpty", "LENGTH(TRIM(\"Characters\")) > 0");
                tableBuilder.HasCheckConstraint("CK_Word_Characters_MaxLength", "LENGTH(TRIM(\"Characters\")) <= 256");
                tableBuilder.HasCheckConstraint("CK_Word_Pronunciation_NullOrNotEmpty", "\"Pronunciation\" IS NULL OR LENGTH(TRIM(\"Pronunciation\")) > 0");
                tableBuilder.HasCheckConstraint("CK_Word_Pronunciation_NullOrMaxLength", "\"Pronunciation\" IS NULL OR LENGTH(TRIM(\"Pronunciation\")) <= 512");
                tableBuilder.HasCheckConstraint("CK_Word_Meaning_NullOrNotEmpty", "\"Meaning\" IS NULL OR LENGTH(TRIM(\"Meaning\")) > 0");
                tableBuilder.HasCheckConstraint("CK_Word_Meaning_NullOrMaxLength", "\"Meaning\" IS NULL OR LENGTH(TRIM(\"Meaning\")) <= 512");
            });
        });

        modelBuilder.Entity<WordGroup>(entityBuilder =>
        {
            entityBuilder.HasKey(entity => entity.Id);

            entityBuilder.HasAlternateKey(entity => entity.Caption);

            entityBuilder.Property(entity => entity.CreatedOn).HasDefaultValueSql(c_currentTimestampUtcSql);
            entityBuilder.Property(entity => entity.UpdatedOn).HasDefaultValueSql(c_currentTimestampUtcSql);

            entityBuilder.ToTable("WordGroup", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint("CK_WordGroup_Caption_NotEmpty", "LENGTH(TRIM(\"Caption\")) > 0");
                tableBuilder.HasCheckConstraint("CK_WordGroup_Caption_MaxLength", "LENGTH(TRIM(\"Caption\")) <= 256");
                tableBuilder.HasCheckConstraint("CK_WordGroup_Comment_NullOrNotEmpty", "\"Comment\" IS NULL OR LENGTH(TRIM(\"Comment\")) > 0");
                tableBuilder.HasCheckConstraint("CK_WordGroup_Comment_NullOrMaxLength", "\"Comment\" IS NULL OR LENGTH(TRIM(\"Comment\")) <= 2048");
            });
        });

        modelBuilder.Entity<WordTag>(entityBuilder =>
        {
            entityBuilder.HasKey(entity => new { entity.WordId, entity.TagId });

            entityBuilder.HasOne(entity => entity.Word)
                .WithMany(entity => entity.WordTags)
                .HasForeignKey(entity => entity.WordId)
                .OnDelete(DeleteBehavior.Cascade);
            entityBuilder.HasOne(entity => entity.Tag)
                .WithMany()
                .HasForeignKey(entity => entity.TagId)
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasIndex(entity => entity.WordId)
                .HasDatabaseName("IX_WordTag_WordId");
            entityBuilder.HasIndex(entity => entity.TagId)
                .HasDatabaseName("IX_WordTag_TagId");

            entityBuilder.ToTable("WordTag", tableBuilder =>
            {
            });
        });

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTimeOffset>().HaveConversion<DateTimeOffsetToStringConverter>();
    }
}
