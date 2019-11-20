using System;
using Microsoft.Extensions.Localization;

namespace ScaleHQ.AspNetCore.LHQ
{
    public class StringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IStringLocalizer _stringLocalizer;

        public StringLocalizerFactory(IStringLocalizer stringLocalizer)
        {
            _stringLocalizer = stringLocalizer ?? throw new ArgumentNullException(nameof(stringLocalizer));
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return _stringLocalizer;
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return _stringLocalizer;
        }
    }
}
