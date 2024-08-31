using System;
using System.Xml.Serialization;

namespace JapaneseLanguageTools.Data.Xml.Models;

[XmlRoot(WordGroupXmlElementName)]
public class WordGroupXmlModel
{
    public const string WordGroupXmlElementName = "WordGroup";

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
    [XmlArrayItem(WordXmlModel.WordXmlElementName)]
    public WordXmlModel[] Words { get; set; } = [];

    public WordGroupXmlModel()
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
