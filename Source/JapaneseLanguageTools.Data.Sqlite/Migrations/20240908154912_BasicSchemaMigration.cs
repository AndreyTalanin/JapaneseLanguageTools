using Microsoft.EntityFrameworkCore.Migrations;

namespace JapaneseLanguageTools.Data.Sqlite.Migrations;

public partial class BasicSchemaMigration : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase(collation: "NOCASE", oldCollation: "BINARY");

        migrationBuilder.CreateTable(
            name: "Tag",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Caption = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                PlaceholderMarker = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: true),
                CreatedOn = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "STRFTIME('%F %T+00:00', 'now')"),
                UpdatedOn = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "STRFTIME('%F %T+00:00', 'now')")
            },
            constraints: table =>
            {
                table.PrimaryKey(name: "PK_Tag", columns: x => x.Id);

                table.UniqueConstraint(name: "AK_Tag_Caption", columns: x => x.Caption);

                table.CheckConstraint(name: "CK_Tag_Caption_NotEmpty", sql: "LENGTH(TRIM(\"Caption\")) > 0");
                table.CheckConstraint(name: "CK_Tag_Caption_MaxLength", sql: "LENGTH(TRIM(\"Caption\")) <= 256");
                table.CheckConstraint(name: "CK_Tag_PlaceholderMarker_NullOrNotEmpty", sql: "\"PlaceholderMarker\" IS NULL OR LENGTH(TRIM(\"PlaceholderMarker\")) > 0");
                table.CheckConstraint(name: "CK_Tag_PlaceholderMarker_NullOrMaxLength", sql: "\"PlaceholderMarker\" IS NULL OR LENGTH(TRIM(\"PlaceholderMarker\")) <= 2048");
            });

        migrationBuilder.CreateTable(
            name: "CharacterGroup",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Caption = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                Comment = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: true),
                Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                CreatedOn = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "STRFTIME('%F %T+00:00', 'now')"),
                UpdatedOn = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "STRFTIME('%F %T+00:00', 'now')")
            },
            constraints: table =>
            {
                table.PrimaryKey(name: "PK_CharacterGroup", columns: x => x.Id);

                table.UniqueConstraint(name: "AK_CharacterGroup_Caption", columns: x => x.Caption);

                table.CheckConstraint(name: "CK_CharacterGroup_Caption_NotEmpty", sql: "LENGTH(TRIM(\"Caption\")) > 0");
                table.CheckConstraint(name: "CK_CharacterGroup_Caption_MaxLength", sql: "LENGTH(TRIM(\"Caption\")) <= 256");
                table.CheckConstraint(name: "CK_CharacterGroup_Comment_NullOrNotEmpty", sql: "\"Comment\" IS NULL OR LENGTH(TRIM(\"Comment\")) > 0");
                table.CheckConstraint(name: "CK_CharacterGroup_Comment_NullOrMaxLength", sql: "\"Comment\" IS NULL OR LENGTH(TRIM(\"Comment\")) <= 2048");
            });

        migrationBuilder.CreateTable(
            name: "WordGroup",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Caption = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                Comment = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: true),
                Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                CreatedOn = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "STRFTIME('%F %T+00:00', 'now')"),
                UpdatedOn = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "STRFTIME('%F %T+00:00', 'now')")
            },
            constraints: table =>
            {
                table.PrimaryKey(name: "PK_WordGroup", columns: x => x.Id);

                table.UniqueConstraint(name: "AK_WordGroup_Caption", columns: x => x.Caption);

                table.CheckConstraint(name: "CK_WordGroup_Caption_NotEmpty", sql: "LENGTH(TRIM(\"Caption\")) > 0");
                table.CheckConstraint(name: "CK_WordGroup_Caption_MaxLength", sql: "LENGTH(TRIM(\"Caption\")) <= 256");
                table.CheckConstraint(name: "CK_WordGroup_Comment_NullOrNotEmpty", sql: "\"Comment\" IS NULL OR LENGTH(TRIM(\"Comment\")) > 0");
                table.CheckConstraint(name: "CK_WordGroup_Comment_NullOrMaxLength", sql: "\"Comment\" IS NULL OR LENGTH(TRIM(\"Comment\")) <= 2048");
            });

        migrationBuilder.CreateTable(
            name: "Character",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                CharacterGroupId = table.Column<int>(type: "INTEGER", nullable: true),
                Symbol = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                Type = table.Column<int>(type: "INTEGER", nullable: false),
                Pronunciation = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                Syllable = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                Onyomi = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                Kunyomi = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                Meaning = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                CreatedOn = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "STRFTIME('%F %T+00:00', 'now')"),
                UpdatedOn = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "STRFTIME('%F %T+00:00', 'now')")
            },
            constraints: table =>
            {
                table.PrimaryKey(name: "PK_Character", columns: x => x.Id);

                table.ForeignKey(
                    name: "FK_Character_CharacterGroup_CharacterGroupId",
                    column: x => x.CharacterGroupId,
                    principalTable: "CharacterGroup",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);

                table.CheckConstraint(name: "CK_Character_Symbol_NotEmpty", sql: "LENGTH(TRIM(\"Symbol\")) > 0");
                table.CheckConstraint(name: "CK_Character_Symbol_MaxLength", sql: "LENGTH(TRIM(\"Symbol\")) <= 16");
                table.CheckConstraint(name: "CK_Character_Pronunciation_NullOrNotEmpty", sql: "\"Pronunciation\" IS NULL OR LENGTH(TRIM(\"Pronunciation\")) > 0");
                table.CheckConstraint(name: "CK_Character_Pronunciation_NullOrMaxLength", sql: "\"Pronunciation\" IS NULL OR LENGTH(TRIM(\"Pronunciation\")) <= 32");
                table.CheckConstraint(name: "CK_Character_Syllable_NullOrNotEmpty", sql: "\"Syllable\" IS NULL OR LENGTH(TRIM(\"Syllable\")) > 0");
                table.CheckConstraint(name: "CK_Character_Syllable_NullOrMaxLength", sql: "\"Syllable\" IS NULL OR LENGTH(TRIM(\"Syllable\")) <= 32");
                table.CheckConstraint(name: "CK_Character_Onyomi_NullOrNotEmpty", sql: "\"Onyomi\" IS NULL OR LENGTH(TRIM(\"Onyomi\")) > 0");
                table.CheckConstraint(name: "CK_Character_Onyomi_NullOrMaxLength", sql: "\"Onyomi\" IS NULL OR LENGTH(TRIM(\"Onyomi\")) <= 256");
                table.CheckConstraint(name: "CK_Character_Kunyomi_NullOrNotEmpty", sql: "\"Kunyomi\" IS NULL OR LENGTH(TRIM(\"Kunyomi\")) > 0");
                table.CheckConstraint(name: "CK_Character_Kunyomi_NullOrMaxLength", sql: "\"Kunyomi\" IS NULL OR LENGTH(TRIM(\"Kunyomi\")) <= 256");
                table.CheckConstraint(name: "CK_Character_Meaning_NullOrNotEmpty", sql: "\"Meaning\" IS NULL OR LENGTH(TRIM(\"Meaning\")) > 0");
                table.CheckConstraint(name: "CK_Character_Meaning_NullOrMaxLength", sql: "\"Meaning\" IS NULL OR LENGTH(TRIM(\"Meaning\")) <= 512");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Character_CharacterGroupId",
            table: "Character",
            column: "CharacterGroupId");

        migrationBuilder.CreateTable(
            name: "CharacterTag",
            columns: table => new
            {
                CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                TagId = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey(name: "PK_CharacterTag", columns: x => new { x.CharacterId, x.TagId });

                table.ForeignKey(
                    name: "FK_CharacterTag_Character_CharacterId",
                    column: x => x.CharacterId,
                    principalTable: "Character",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_CharacterTag_Tag_TagId",
                    column: x => x.TagId,
                    principalTable: "Tag",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_CharacterTag_CharacterId",
            table: "CharacterTag",
            column: "CharacterId");

        migrationBuilder.CreateIndex(
            name: "IX_CharacterTag_TagId",
            table: "CharacterTag",
            column: "TagId");

        migrationBuilder.CreateTable(
            name: "Word",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                WordGroupId = table.Column<int>(type: "INTEGER", nullable: true),
                Characters = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                CharacterTypes = table.Column<int>(type: "INTEGER", nullable: false),
                Pronunciation = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                Meaning = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                CreatedOn = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "STRFTIME('%F %T+00:00', 'now')"),
                UpdatedOn = table.Column<string>(type: "TEXT", nullable: false, defaultValueSql: "STRFTIME('%F %T+00:00', 'now')")
            },
            constraints: table =>
            {
                table.PrimaryKey(name: "PK_Word", columns: x => x.Id);

                table.ForeignKey(
                    name: "FK_Word_WordGroup_WordGroupId",
                    column: x => x.WordGroupId,
                    principalTable: "WordGroup",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);

                table.CheckConstraint(name: "CK_Word_Characters_NotEmpty", sql: "LENGTH(TRIM(\"Characters\")) > 0");
                table.CheckConstraint(name: "CK_Word_Characters_MaxLength", sql: "LENGTH(TRIM(\"Characters\")) <= 256");
                table.CheckConstraint(name: "CK_Word_Pronunciation_NullOrNotEmpty", sql: "\"Pronunciation\" IS NULL OR LENGTH(TRIM(\"Pronunciation\")) > 0");
                table.CheckConstraint(name: "CK_Word_Pronunciation_NullOrMaxLength", sql: "\"Pronunciation\" IS NULL OR LENGTH(TRIM(\"Pronunciation\")) <= 512");
                table.CheckConstraint(name: "CK_Word_Meaning_NullOrNotEmpty", sql: "\"Meaning\" IS NULL OR LENGTH(TRIM(\"Meaning\")) > 0");
                table.CheckConstraint(name: "CK_Word_Meaning_NullOrMaxLength", sql: "\"Meaning\" IS NULL OR LENGTH(TRIM(\"Meaning\")) <= 512");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Word_WordGroupId",
            table: "Word",
            column: "WordGroupId");

        migrationBuilder.CreateTable(
            name: "WordTag",
            columns: table => new
            {
                WordId = table.Column<int>(type: "INTEGER", nullable: false),
                TagId = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey(name: "PK_WordTag", columns: x => new { x.WordId, x.TagId });

                table.ForeignKey(
                    name: "FK_WordTag_Word_WordId",
                    column: x => x.WordId,
                    principalTable: "Word",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_WordTag_Tag_TagId",
                    column: x => x.TagId,
                    principalTable: "Tag",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_WordTag_WordId",
            table: "WordTag",
            column: "WordId");

        migrationBuilder.CreateIndex(
            name: "IX_WordTag_TagId",
            table: "WordTag",
            column: "TagId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase(collation: "BINARY", oldCollation: "NOCASE");

        migrationBuilder.DropTable(name: "CharacterTag");

        migrationBuilder.DropTable(name: "Character");

        migrationBuilder.DropTable(name: "WordTag");

        migrationBuilder.DropTable(name: "Word");

        migrationBuilder.DropTable(name: "CharacterGroup");

        migrationBuilder.DropTable(name: "WordGroup");

        migrationBuilder.DropTable(name: "Tag");
    }
}
