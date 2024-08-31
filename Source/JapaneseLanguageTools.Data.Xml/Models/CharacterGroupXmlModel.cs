using System;
using System.Xml.Serialization;

namespace JapaneseLanguageTools.Data.Xml.Models;

[XmlRoot(CharacterGroupXmlElementName)]
public class CharacterGroupXmlModel
{
    public const string CharacterGroupXmlElementName = "CharacterGroup";

    [XmlAttribute]
    public int Id { get; set; }

    [XmlAttribute]
    public string Caption { get; set; } = string.Empty;

    [XmlElement]
    public string? Comment { get; set; }

    [XmlAttribute]
    public bool Enabled { get; set; }

    /// <remarks>See the <see cref="CreatedOnString" /> property.</remarks>
    [XmlIgnore]
    public DateTimeOffset CreatedOn { get; set; }

    /// <remarks>See the <see cref="UpdatedOnString" /> property.</remarks>
    [XmlIgnore]
    public DateTimeOffset UpdatedOn { get; set; }

    [XmlArray]
    [XmlArrayItem(CharacterXmlModel.CharacterXmlElementName)]
    public CharacterXmlModel[] Characters { get; set; } = [];

    public CharacterGroupXmlModel()
    {
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
