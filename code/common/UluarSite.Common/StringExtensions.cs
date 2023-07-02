namespace UluarSite.Common;
public static class StringExtensions {
    public static string Truncate(this string value, int maxChars) {
        if (value == null) {
            return string.Empty;
        }
        if (value.Length <= maxChars) {
            return value;
        }
        return value[..maxChars] + " ..";
    }
}
