using System.Xml.Serialization;

using JapaneseLanguageTools.Contracts.Enums;

namespace JapaneseLanguageTools.Data.Xml.Models;

public class CharacterXmlModel
{
    [XmlAttribute("Type")]
    public CharacterTypes Type { get; set; }

    [XmlAttribute("Symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <remarks>Applicable only for <see cref="CharacterTypes.Hiragana" /> and <see cref="CharacterTypes.Katakana" />.</remarks>
    [XmlAttribute("Pronunciation")]
    public string? Pronunciation { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Hiragana" /> and <see cref="CharacterTypes.Katakana" />.</remarks>
    [XmlAttribute("Syllable")]
    public string? Syllable { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Kanji" />.</remarks>
    [XmlAttribute("Onyomi")]
    public string? Onyomi { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Kanji" />.</remarks>
    [XmlAttribute("Kunyomi")]
    public string? Kunyomi { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Kanji" />.</remarks>
    [XmlAttribute("Meaning")]
    public string? Meaning { get; set; }

    /// <remarks>The <see cref="string" /> value contains a comma- or semicolon-separated list of tags.</remarks>
    [XmlAttribute("Tags")]
    public string? Tags { get; set; }
}
