using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using JapaneseLanguageTools.Contracts.Enums;

namespace JapaneseLanguageTools.Data.Entities;

public class Character
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? CharacterGroupId { get; set; }

    [StringLength(16)]
    public string Symbol { get; set; } = string.Empty;

    public CharacterTypes Type { get; set; }

    [StringLength(32)]
    public string? Pronunciation { get; set; }

    [StringLength(32)]
    public string? Syllable { get; set; }

    [StringLength(256)]
    public string? Onyomi { get; set; }

    [StringLength(256)]
    public string? Kunyomi { get; set; }

    [StringLength(512)]
    public string? Meaning { get; set; }

    /// <remarks>
    /// Do not decorate with the <see cref="DatabaseGeneratedAttribute" /> attribute using the <see cref="DatabaseGeneratedOption.Computed" /> option
    /// as it allows Entity Framework Core to skip the column on updates, and SQLite does not provide an option to update columns automatically.
    /// </remarks>
    public DateTimeOffset CreatedOn { get; set; }

    /// <remarks>
    /// Do not decorate with the <see cref="DatabaseGeneratedAttribute" /> attribute using the <see cref="DatabaseGeneratedOption.Computed" /> option
    /// as it allows Entity Framework Core to skip the column on updates, and SQLite does not provide an option to update columns automatically.
    /// </remarks>
    public DateTimeOffset UpdatedOn { get; set; }

    public IList<CharacterTag> CharacterTags { get; set; } = new List<CharacterTag>();

    public CharacterGroup? CharacterGroup { get; set; }
}
