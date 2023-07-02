using Newtonsoft.Json;

namespace UluarSite.Common;

public static class ObjectExtensions {
    private const string Null = "null";

    public static string ToJson(this object? value, Formatting formatting = Formatting.Indented) {
        if (value == null) return Null;
        try {
            string json = JsonConvert.SerializeObject(value, new JsonSerializerSettings {
                Formatting = formatting,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        } catch (Exception e1) {
            //log exception but dont throw one
            return e1.Message;
        }
    }

    public static int SafeCount<T>(this IEnumerable<T>? source) {
        return source?.Count() ?? 0;
    }

    public static List<T> SafeToList<T>(this IEnumerable<T>? source) {
        return source == null ? Enumerable.Empty<T>().ToList() : source.ToList();
    }

    public static T[] SafeToArray<T>(this IEnumerable<T>? source) {
        return source == null ? Enumerable.Empty<T>().ToArray() : source.ToArray();
    }
}
