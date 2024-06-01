using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JapaneseLanguageTools.Data.Entities;

public class WordGroup
{
    [Key]
    public int Id { get; set; }

    [StringLength(256)]
    public string Caption { get; set; } = string.Empty;

    [StringLength(512)]
    public string? Comment { get; set; }

    public bool Enabled { get; set; }

    public IList<Word> Words { get; set; } = [];
}
