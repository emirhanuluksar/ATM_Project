namespace UluarSite.Common;
public static class LanguageUtils {
    public static Tuple<bool, Exception?> IgnoreErrors(Action operation) {
        if (operation == null)
            return Tuple.Create<bool, Exception?>(false, null);
        try {
            operation.Invoke();
        } catch (Exception e) {
            return Tuple.Create<bool, Exception?>(false, e);
        }
        return Tuple.Create<bool, Exception?>(true, null);
    }

    public static Tuple<T?, bool, Exception?> IgnoreErrors<T>(Func<T> operation, T? defaultValue = default) {
        if (operation == null)
            return Tuple.Create<T?, bool, Exception?>(defaultValue, false, null);

        T result;
        try {
            result = operation.Invoke();
        } catch (Exception e) {
            return Tuple.Create<T?, bool, Exception?>(default, false, e);
        }
        return Tuple.Create<T?, bool, Exception?>(result, true, null);
    }
}
