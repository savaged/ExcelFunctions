using System.Text;

namespace Savaged.Excel;

public static class TransformationFunctions
{
    private const string PAD_DESCRIPTION =
        "Excel's missing Pad function. Pad with the default zero to the specified count with a specified character. NOTE: Any negative value will be returned positive for the default left-hand side padding.";
    private const string PAD_ARG1 = "Value to pad";
    private const string PAD_ARG2 = "Count of characters after padding";
    private const string PAD_ARG3 = "Padding character (default is '0')";
    private const string PAD_ARG4 = "Padding on right-hand side (default is left)";

    [ExcelFunction(Description = "Converts data to a bespoke unique identifier.")]
    public static string ToUniqueIdentifier(this string data) =>
        string.IsNullOrEmpty(data) ? string.Empty :
        Convert.ToBase64String(Encoding.UTF8.GetBytes(data));

    [ExcelFunction(Description = "Converts a bespoke unique identifier back to data.")]
    public static string FromUniqueIdentifier(this string uid) =>
        string.IsNullOrEmpty(uid) ? string.Empty :
        Encoding.UTF8.GetString(Convert.FromBase64String(uid));

    [ExcelFunction(Description = $"Pad an integer. {PAD_DESCRIPTION}")]
    public static object Pad(
        [ExcelArgument(Description = PAD_ARG1)] this int value,
        [ExcelArgument(Description = PAD_ARG2)] object charCountAfterPadding,
        [ExcelArgument(Description = PAD_ARG3)] object padCharacter,
        [ExcelArgument(Description = PAD_ARG4)] object onRight) =>
        PadStr(
            Unsign<int>(value, false).ToString(),
            charCountAfterPadding.ValueOrDefault(1),
            padCharacter.ValueOrDefault('0'),
            onRight.ValueOrDefault(false));

    [ExcelFunction(Description = $"Pad a double (a number with a decimal place). {PAD_DESCRIPTION}")]
    public static string PadNumberWithDecimalPlaces(
        [ExcelArgument(Description = PAD_ARG1)] this double value,
        [ExcelArgument(Description = PAD_ARG2)] object charCountAfterPadding,
        [ExcelArgument(Description = PAD_ARG3)] object padCharacter,
        [ExcelArgument(Description = PAD_ARG4)] object onRight) =>
        PadStr(
            Unsign<double>(value, false).ToString(),
            charCountAfterPadding.ValueOrDefault(1),
            padCharacter.ValueOrDefault('0'),
            onRight.ValueOrDefault(false));

    [ExcelFunction(Description = $"Pad a string. {PAD_DESCRIPTION}")]
    public static string PadString(
        [ExcelArgument(Description = PAD_ARG1)] this string value,
        [ExcelArgument(Description = PAD_ARG2)] object charCountAfterPadding,
        [ExcelArgument(Description = PAD_ARG3)] object padCharacter,
        [ExcelArgument(Description = PAD_ARG4)] object onRight) =>
        PadStr(
            value,
            charCountAfterPadding.ValueOrDefault(1),
            padCharacter.ValueOrDefault('0'),
            onRight.ValueOrDefault(false));

    private static T Unsign<T>(dynamic value, bool padRighthandside)
        where T : struct =>
        !padRighthandside && value < default(T) ? value * -1 : value;

    private static string PadStr(
        string value,
        int charCountAfterPadding,
        char padCharacter,
        bool padRighthandSide)
    {
        var paddingSize = charCountAfterPadding - value?.Length ?? 0;
        var padding = new string(
            padCharacter == '\0' ? '0' : padCharacter,
            paddingSize < 0 ? 0 : paddingSize);
        return padRighthandSide ? $"{value}{padding}" : $"{padding}{value}";
    }

}
