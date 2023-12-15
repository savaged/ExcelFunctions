namespace Savaged.Excel;

internal static class ObjectExtensions
{
    internal static char ValueOrDefault(this object @this, char defaultValue) =>
        @this is char c ? c : defaultValue;

    internal static int ValueOrDefault(this object @this, int defaultValue) =>
        @this is int i ? i : (int)(@this is double d ? d : defaultValue);

    internal static double ValueOrDefault(this object @this, double defaultValue) =>
        @this is double d ? d : defaultValue;

    internal static bool ValueOrDefault(this object @this, bool defaultValue) =>
        @this is bool b ? b : defaultValue;

}
