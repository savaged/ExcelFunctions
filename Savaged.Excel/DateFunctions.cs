﻿using System.Globalization;

namespace Savaged.Excel;

public static class DateFunctions
{
    [ExcelFunction(Description = "Gets the number of days for a given year.")]
    public static int DaysInYear(int year) =>
        SafelyExecute(y => CultureInfo.CurrentCulture.Calendar.GetDaysInYear(y), year);

    [ExcelFunction(Description = "Gets the number of days starting from a given date.")]
    public static int DaysInYearStarting(DateTime date) =>
        SafelyExecute(d => (date.AddYears(1) - d).Days, date);

    [ExcelFunction(Description = "Is the given year a leap year (TRUE/FALSE).")]
    public static bool IsLeapYear(int year) =>
        SafelyExecute(y => DateTime.IsLeapYear(y), year);

    [ExcelFunction(Description = "Is the given date within a leap year (TRUE/FALSE).")]
    public static bool IsWithinLeapYear(DateTime date) =>
        SafelyExecute(d => DaysInYearStarting(d) == 366, date);

    [ExcelFunction(Description = "Gets a new date after adding the given years to the given date.")]
    public static DateTime AddYears(DateTime date, int years) =>
        SafelyExecute(y => date.AddYears(y), years);

    [ExcelFunction(Description = "Gets a new date after subtracting the given years from the given date.")]
    public static DateTime SubtractYears(DateTime date, int years) => AddYears(date, -years);

    private static O SafelyExecute<I,O>(Func<I,O> f, I input)
        where O : struct
    {
        O output;
        try
        {
            output = f(input);
        }
        catch (ArgumentOutOfRangeException)
        {
            output = default;
        }
        return output;
    }
}