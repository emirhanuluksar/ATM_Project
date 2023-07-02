using System.Collections;
using System.Globalization;
using Newtonsoft.Json;


namespace Odeal.Common;

public static class Util {
    public static bool IsCollectionType(Type type) {
        return type.GetInterface(nameof(ICollection)) != null;
    }

    public static bool IsEnumerableType(Type type) {
        return type.Name != nameof(String)
            && type.GetInterface(nameof(IEnumerable)) != null;
    }
    public static T? DeserializeObject<T>(string input) {
        var result = JsonConvert.DeserializeObject<T>(input);
        return result;
    }
    public static bool CaseInsensitiveCompare(string str1, string str2) {
        CultureInfo turkish = new CultureInfo("tr-TR");
        return string.Compare(str1, str2, true, turkish) == 0;
    }
}
