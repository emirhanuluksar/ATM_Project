using System.Reflection;

namespace UluarSite.Common;
public static class ReclectionUtil {
    public static T? GetPrivateMember<T>(object value, string fieldName, int baseTypeCount = 0) {
        if (null == value)
            throw new ArgumentNullException(nameof(value));
        try {
            var reflected = GetPrivateMemberImpl(value, fieldName, baseTypeCount);
            return (T)reflected!;
        } catch {
            // no-op
        }
        return default;
    }

    private static object? GetPrivateMemberImpl(object value, string fieldName, int baseTypeCount) {
#pragma warning disable S3011
        var type = baseTypeCount == 1 ? value.GetType().BaseType : value.GetType();
        return type
      ?.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance) //NOSONAR
      ?.GetValue(value);
#pragma warning restore S3011
    }
}
