using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseLanguageTools.Data.Entities;

public class CharacterGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(256)]
    public string Caption { get; set; } = string.Empty;

    [StringLength(2048)]
    public string? Comment { get; set; }

    public bool Enabled { get; set; }

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

    public IList<Character> Characters { get; set; } = new List<Character>();
}
