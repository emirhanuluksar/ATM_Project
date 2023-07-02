namespace UluarSite.Common;
public static class ExceptionExtensions {
    private const int MaxDepth = 5;

    public static string Detail(this Exception exception, bool includeInnerExceptions = true, bool includeStackTrace = false, int depth = 1) {
        if (exception is null || depth < 1 || depth > MaxDepth) {
            return string.Empty;
        }
        var innerExceptions = string.Empty;
        if (includeInnerExceptions && exception is not AggregateException && exception.InnerException is not null) {
            innerExceptions = Detail(exception.InnerException, includeInnerExceptions, false, depth + 1);
        }
        var result = innerExceptions == string.Empty ? exception.Message : $"{exception.Message}{Environment.NewLine}{string.Concat(Enumerable.Repeat("==", depth))}> {innerExceptions}";
        return includeStackTrace ? $"{result}{Environment.NewLine}{Environment.NewLine}{exception.StackTrace}" : result;
    }
}
