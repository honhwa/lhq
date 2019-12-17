#if !ASP_NET_CORE1
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Localization;

namespace ScaleHQ.AspNetCore.LHQ
{
    public class DisplayNameDetailsProvider : IDisplayMetadataProvider
    {
        private static IStringLocalizer _stringLocalizer;

        public static void SetStringLocalizer(IStringLocalizer stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            var displayAttribute = context.Attributes.OfType<DisplayAttribute>().FirstOrDefault();
            if (displayAttribute != null)
            {
                context.DisplayMetadata.DisplayName = () => GetLocalizedDisplayName(displayAttribute);
            }
        }

        private string GetLocalizedDisplayName(DisplayAttribute displayAttribute)
        {
            return _stringLocalizer[displayAttribute.Name];
        }
    }
}
#endif