using JapaneseLanguageTools.Contracts.Enums;

namespace JapaneseLanguageTools.Contracts.Models;

public class CharacterModel
{
    public int Id { get; set; }

    public int? CharacterGroupId { get; set; }

    public string Symbol { get; set; } = string.Empty;

    public CharacterTypes Type { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Hiragana" /> and <see cref="CharacterTypes.Katakana" />.</remarks>
    public string? Pronunciation { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Hiragana" /> and <see cref="CharacterTypes.Katakana" />.</remarks>
    public string? Syllable { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Kanji" />.</remarks>
    public string? Onyomi { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Kanji" />.</remarks>
    public string? Kunyomi { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Kanji" />.</remarks>
    public string? Meaning { get; set; }
}
