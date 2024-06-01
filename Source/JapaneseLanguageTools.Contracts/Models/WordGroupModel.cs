using System.Collections.Generic;

namespace JapaneseLanguageTools.Contracts.Models;

public class WordGroupModel
{
    public int Id { get; set; }

    public string Caption { get; set; } = string.Empty;

    public string? Comment { get; set; }

    public bool Enabled { get; set; }

    public IList<WordModel> Words { get; set; } = [];
}
