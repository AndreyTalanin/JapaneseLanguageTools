using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using JapaneseLanguageTools.Contracts.Models;
using JapaneseLanguageTools.Data.Xml.Models;

namespace JapaneseLanguageTools.Core.AutoMapper;

public class ApplicationDictionaryXmlSerializationProfile : Profile
{
    public ApplicationDictionaryXmlSerializationProfile()
    {
        SourceMemberNamingConvention = ExactMatchNamingConvention.Instance;
        DestinationMemberNamingConvention = ExactMatchNamingConvention.Instance;

        CreateMap<CharacterModel, CharacterXmlModel>()
            .ForMember(xmlModel => xmlModel.Tags, options => options.MapFrom(model => model.CharacterTags))
            .ForMember(xmlModel => xmlModel.CharacterGroupIdString, options => options.Ignore())
            .ForMember(xmlModel => xmlModel.CreatedOnString, options => options.Ignore())
            .ForMember(xmlModel => xmlModel.UpdatedOnString, options => options.Ignore());
        CreateMap<CharacterGroupModel, CharacterGroupXmlModel>()
            .ForMember(xmlModel => xmlModel.CreatedOnString, options => options.Ignore())
            .ForMember(xmlModel => xmlModel.UpdatedOnString, options => options.Ignore());

        CreateMap<IEnumerable<TagModel>, string>().ConstructUsing((tags, context) =>
        {
            return string.Join("; ", tags.Select(tag => tag.Caption));
        });
    }
}
