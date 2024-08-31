using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseLanguageTools.Contracts.Models;

public class WordGroupModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(256)]
    public string Caption { get; set; } = string.Empty;

    [StringLength(2048)]
    public string? Comment { get; set; }

    public bool Enabled { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTimeOffset CreatedOn { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTimeOffset UpdatedOn { get; set; }

    public IList<WordModel> Words { get; set; } = new List<WordModel>();
}
