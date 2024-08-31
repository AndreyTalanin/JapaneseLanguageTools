using System;
using System.Xml.Serialization;

using JapaneseLanguageTools.Contracts.Enums;

namespace JapaneseLanguageTools.Data.Xml.Models;

[XmlRoot(CharacterXmlElementName)]
public class CharacterXmlModel
{
    public const string CharacterXmlElementName = "Character";

    [XmlAttribute]
    public int Id { get; set; }

    /// <remarks>See the <see cref="CharacterGroupIdString" /> property.</remarks>
    [XmlIgnore]
    public int? CharacterGroupId { get; set; }

    [XmlAttribute]
    public string Symbol { get; set; } = string.Empty;

    [XmlAttribute]
    public CharacterTypes Type { get; set; }

    [XmlAttribute]
    public string? Pronunciation { get; set; }

    [XmlAttribute]
    public string? Syllable { get; set; }

    [XmlAttribute]
    public string? Onyomi { get; set; }

    [XmlAttribute]
    public string? Kunyomi { get; set; }

    [XmlAttribute]
    public string? Meaning { get; set; }

    /// <remarks>See the <see cref="CreatedOnString" /> property.</remarks>
    [XmlIgnore]
    public DateTimeOffset CreatedOn { get; set; }

    /// <remarks>See the <see cref="UpdatedOnString" /> property.</remarks>
    [XmlIgnore]
    public DateTimeOffset UpdatedOn { get; set; }

    /// <remarks>The <see cref="string" /> value contains a comma- or semicolon-separated list of tags.</remarks>
    [XmlAttribute]
    public string? Tags { get; set; }

    public CharacterXmlModel()
    {
    }

    [XmlAttribute(nameof(CharacterGroupId))]
    public string? CharacterGroupIdString
    {
        get => CharacterGroupId.ToString();
        set => CharacterGroupId = !string.IsNullOrEmpty(value) ? int.Parse(value) : null;
    }

    [XmlAttribute(nameof(CreatedOn))]
    public string? CreatedOnString
    {
        get => CreatedOn.ToString("u");
        set => CreatedOn = !string.IsNullOrEmpty(value) ? DateTimeOffset.Parse(value) : default(DateTimeOffset);
    }

    [XmlAttribute(nameof(UpdatedOn))]
    public string? UpdatedOnString
    {
        get => UpdatedOn.ToString("u");
        set => UpdatedOn = !string.IsNullOrEmpty(value) ? DateTimeOffset.Parse(value) : default(DateTimeOffset);
    }
}
