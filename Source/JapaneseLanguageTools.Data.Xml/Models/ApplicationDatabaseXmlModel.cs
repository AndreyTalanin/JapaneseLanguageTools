using System.Xml.Serialization;

namespace JapaneseLanguageTools.Data.Xml.Models;

[XmlRoot(ApplicationDatabaseXmlElementName)]
public class ApplicationDatabaseXmlModel
{
    public const string ApplicationDatabaseXmlElementName = "ApplicationDatabase";

    [XmlArray]
    [XmlArrayItem(CharacterXmlModel.CharacterXmlElementName)]
    public CharacterXmlModel[] Characters { get; set; } = [];

    [XmlArray]
    [XmlArrayItem(CharacterGroupXmlModel.CharacterGroupXmlElementName)]
    public CharacterGroupXmlModel[] CharacterGroups { get; set; } = [];

    [XmlArray]
    [XmlArrayItem(WordXmlModel.WordXmlElementName)]
    public WordXmlModel[] Words { get; set; } = [];

    [XmlArray]
    [XmlArrayItem(WordGroupXmlModel.WordGroupXmlElementName)]
    public WordGroupXmlModel[] WordGroups { get; set; } = [];

    [XmlArray]
    [XmlArrayItem(TagXmlModel.TagXmlElementName)]
    public TagXmlModel[] Tags { get; set; } = [];
}
