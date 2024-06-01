using JapaneseLanguageTools.Contracts.Enums;

namespace JapaneseLanguageTools.Contracts.Models;

public class WordModel
{
    public int Id { get; set; }

    public string Characters { get; set; } = string.Empty;

    public CharacterTypes Types { get; set; }

    public string Pronunciation { get; set; } = string.Empty;

    public string Meaning { get; set; } = string.Empty;
}
