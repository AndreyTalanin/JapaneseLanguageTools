using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using JapaneseLanguageTools.Contracts.Enums;

namespace JapaneseLanguageTools.Data.Entities;

public class Word
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? WordGroupId { get; set; }

    [StringLength(256)]
    public string Characters { get; set; } = string.Empty;

    public CharacterTypes CharacterTypes { get; set; }

    [StringLength(512)]
    public string? Pronunciation { get; set; }

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

    public IList<WordTag> WordTags { get; set; } = new List<WordTag>();

    public WordGroup? WordGroup { get; set; }
}
