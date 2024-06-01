using System.Xml.Serialization;

using JapaneseLanguageTools.Contracts.Enums;

namespace JapaneseLanguageTools.Data.Xml.Models;

public class WordXmlModel
{
    [XmlAttribute("Types")]
    public CharacterTypes Types { get; set; }

    [XmlAttribute("Characters")]
    public string Characters { get; set; } = string.Empty;

    [XmlAttribute("Pronunciation")]
    public string Pronunciation { get; set; } = string.Empty;

    [XmlAttribute("Meaning")]
    public string Meaning { get; set; } = string.Empty;

    /// <remarks>The <see cref="string" /> value contains a comma- or semicolon-separated list of tags.</remarks>
    [XmlAttribute("Tags")]
    public string? Tags { get; set; }
}
