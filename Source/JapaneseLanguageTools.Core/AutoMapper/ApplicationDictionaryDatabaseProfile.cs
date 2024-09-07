using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using JapaneseLanguageTools.Contracts.Models;
using JapaneseLanguageTools.Data.Entities;

namespace JapaneseLanguageTools.Core.AutoMapper;

public class ApplicationDictionaryDatabaseProfile : Profile
{
    public ApplicationDictionaryDatabaseProfile()
    {
        SourceMemberNamingConvention = ExactMatchNamingConvention.Instance;
        DestinationMemberNamingConvention = ExactMatchNamingConvention.Instance;

        CreateMap<Character, CharacterModel>();
        CreateMap<CharacterGroup, CharacterGroupModel>();

        CreateMap<IEnumerable<CharacterTag>, IList<TagModel>>().ConstructUsing((characters, context) =>
        {
            return characters
                .Select(character => character.Tag)
                .Select(tag => context.Mapper.Map<TagModel>(tag))
                .ToList();
        });
    }
}
