using System.Runtime.Serialization;

namespace Checkout.Application.Extensions;

public static class StringExtensions
{
    public static T? ToEnum<T>(this string str)
    {
        var enumType = typeof(T);

        foreach (var name in Enum.GetNames(enumType))
        {
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            if (enumMemberAttribute.Value?.ToLower() == str?.ToLower()) return (T)Enum.Parse(enumType, name);
        }

        return default(T);
    }
}