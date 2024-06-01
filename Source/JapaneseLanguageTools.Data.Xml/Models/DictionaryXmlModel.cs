using System.Xml.Serialization;

namespace JapaneseLanguageTools.Data.Xml.Models;

[XmlRoot("Dictionary")]
public class DictionaryXmlModel
{
    [XmlArray("Characters")]
    [XmlArrayItem("Character")]
    public CharacterXmlModel[] Characters { get; set; } = [];

    [XmlArray("CharacterGroups")]
    [XmlArrayItem("CharacterGroup")]
    public CharacterGroupXmlModel[] CharacterGroups { get; set; } = [];

    [XmlArray("Words")]
    [XmlArrayItem("Word")]
    public WordXmlModel[] Words { get; set; } = [];

    [XmlArray("WordGroups")]
    [XmlArrayItem("WordGroup")]
    public WordGroupXmlModel[] WordGroups { get; set; } = [];
}
