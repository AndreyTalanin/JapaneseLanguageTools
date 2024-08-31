using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseLanguageTools.Data.Entities;

public class Tag
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(256)]
    public string Caption { get; set; } = string.Empty;

    [StringLength(2048)]
    public string? PlaceholderMarker { get; set; }

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
}
