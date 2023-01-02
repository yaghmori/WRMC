using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WRMC.Core.Shared.Extensions
{
    public static class EnumExtensions
    {
        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            var enumType = enumValue.GetType();

            return enumType
                .GetMember(enumValue.ToString())?
                .Where(x => x.MemberType == MemberTypes.Field && ((FieldInfo)x).FieldType == enumType)
                .First()
                .GetCustomAttribute<DisplayAttribute>()?.Name ?? enumValue.ToString();
        }
        public static string GetDisplayDescription(this Enum enumValue)
        {
            var enumType = enumValue.GetType();

            return enumType
                .GetMember(enumValue.ToString())?
                .Where(x => x.MemberType == MemberTypes.Field && ((FieldInfo)x).FieldType == enumType)
                .First()
                .GetCustomAttribute<DisplayAttribute>()?.Description ?? enumValue.ToString();
        }

        public static string GetDisplayShortName(this Enum enumValue)
        {
            var enumType = enumValue.GetType();

            return enumType
                .GetMember(enumValue.ToString())?
                .Where(x => x.MemberType == MemberTypes.Field && ((FieldInfo)x).FieldType == enumType)
                .First()
                .GetCustomAttribute<DisplayAttribute>()?.ShortName ?? enumValue.ToString();
        }

        public static string GetDisplayOrder(this Enum enumValue)
        {
            var enumType = enumValue.GetType();

            return enumType
                .GetMember(enumValue.ToString())?
                .Where(x => x.MemberType == MemberTypes.Field && ((FieldInfo)x).FieldType == enumType)
                .First()
                .GetCustomAttribute<DisplayAttribute>()?.Order.ToString() ?? enumValue.ToString();
        }

        public static string GetDisplayGroupName(this Enum enumValue)
        {
            var enumType = enumValue.GetType();

            return enumType
                .GetMember(enumValue.ToString())?
                .Where(x => x.MemberType == MemberTypes.Field && ((FieldInfo)x).FieldType == enumType)
                .First()
                .GetCustomAttribute<DisplayAttribute>()?.GroupName ?? enumValue.ToString();
        }


        public static string GetDescription(this Enum enumValue)
        {
            var enumType = enumValue.GetType();

            return enumType
                .GetMember(enumValue.ToString())?
                .Where(x => x.MemberType == MemberTypes.Field && ((FieldInfo)x).FieldType == enumType)
                .First()
                .GetCustomAttribute<DescriptionAttribute>()?.Description ?? enumValue.ToString();
        }

    }
}
