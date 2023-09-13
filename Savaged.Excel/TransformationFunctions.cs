using System.Text;

namespace Savaged.Excel;

public static class TransformationFunctions
{
    [ExcelFunction(Description = "Converts data to a bespoke unique identifier.")]
    public static string ToUniqueIdentifier(this string data) =>
        string.IsNullOrEmpty(data) ? string.Empty :
        Convert.ToBase64String(Encoding.UTF8.GetBytes(data));

    [ExcelFunction(Description = "Converts a bespoke unique identifier back to data.")]
    public static string FromUniqueIdentifier(this string uid) =>
        string.IsNullOrEmpty(uid) ? string.Empty :
        Encoding.UTF8.GetString(Convert.FromBase64String(uid));
}
