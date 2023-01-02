using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace WRMC.RootComponents.Extensions
{
    public static class StringLocalizerHelper
        {
            public static MarkupString Html<T>(
               this IStringLocalizer<T> localizer,
               string key,
               params object[] arguments)
            {
                return new MarkupString(localizer[key, arguments]);
            }
        }

}
