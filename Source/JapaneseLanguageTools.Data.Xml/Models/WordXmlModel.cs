using System;
using System.Xml.Serialization;

using JapaneseLanguageTools.Contracts.Enums;

namespace JapaneseLanguageTools.Data.Xml.Models;

[XmlRoot(WordXmlElementName)]
public class WordXmlModel
{
    public const string WordXmlElementName = "Word";

    [XmlAttribute]
    public int Id { get; set; }

    /// <remarks>See the <see cref="WordGroupIdString" /> property.</remarks>
    [XmlIgnore]
    public int? WordGroupId { get; set; }

    [XmlAttribute]
    public string Characters { get; set; } = string.Empty;

    /// <remarks>See the <see cref="CharacterTypesString" /> property.</remarks>
    [XmlIgnore]
    public CharacterTypes CharacterTypes { get; set; }

    [XmlAttribute]
    public string? Pronunciation { get; set; }

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

    public WordXmlModel()
    {
    }

    [XmlAttribute(nameof(WordGroupId))]
    public string? WordGroupIdString
    {
        get => WordGroupId.ToString();
        set => WordGroupId = !string.IsNullOrEmpty(value) ? int.Parse(value) : null;
    }

    [XmlAttribute(nameof(CharacterTypes))]
    public string CharacterTypesString
    {
        get => CharacterTypes.ToString();
        set => CharacterTypes = !string.IsNullOrEmpty(value) ? Enum.Parse<CharacterTypes>(value.Replace(';', ',')) : CharacterTypes.None;
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
