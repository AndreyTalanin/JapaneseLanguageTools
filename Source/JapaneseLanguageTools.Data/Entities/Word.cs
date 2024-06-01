using System.ComponentModel.DataAnnotations;

using JapaneseLanguageTools.Contracts.Enums;

namespace JapaneseLanguageTools.Data.Entities;

public class Word
{
    [Key]
    public int Id { get; set; }

    [StringLength(256)]
    public string Characters { get; set; } = string.Empty;

    public CharacterTypes Types { get; set; }

    [StringLength(512)]
    public string Pronunciation { get; set; } = string.Empty;

    [StringLength(512)]
    public string Meaning { get; set; } = string.Empty;
}
