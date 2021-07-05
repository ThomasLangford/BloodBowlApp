using AutoMapper;
using BloodBowlAPI.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs
{
    public class TranslationResolver : IMemberValueResolver<object, object, string, string>
    {
        private readonly IStringLocalizer<Localization> _localizer;

        public TranslationResolver(IStringLocalizer<Localization> localizer)
        {
            _localizer = localizer;
        }

        public string Resolve(object source, object destination, string sourceMember, string destMember, ResolutionContext context)
        {
            return _localizer[sourceMember];
        }
    }
}
