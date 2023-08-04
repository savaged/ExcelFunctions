using ExcelDna.Integration;
using System.Globalization;

namespace Savaged.Excel;

public static class Functions
{
    [ExcelFunction(Description = "Is the given year a leap year (TRUE/FALSE).")]
    public static bool IsLeapYear(int year) => DateTime.IsLeapYear(year);

    [ExcelFunction(Description = "Gets the number of days for a given year.")]
    public static int DaysInYear(int year) => CultureInfo.CurrentCulture.Calendar.GetDaysInYear(year);


    [ExcelFunction(Description = "Gets the number of days starting from a given date.")]
    public static int DaysInYearStarting(DateTime date) => (date.AddYears(1) - date).Days;

}