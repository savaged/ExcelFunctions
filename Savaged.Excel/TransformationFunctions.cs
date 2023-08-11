using System.Text;

namespace Savaged.Excel
{
    public static class TransformationFunctions
    {
        public static string ToUniqueIdentifier(this string self) =>
            string.IsNullOrEmpty(self) ? string.Empty :
            Convert.ToBase64String(Encoding.UTF8.GetBytes(self));

        public static string FromUniqueIdentifier(this string self) =>
            string.IsNullOrEmpty(self) ? string.Empty :
            Encoding.UTF8.GetString(Convert.FromBase64String(self));
    }
}
