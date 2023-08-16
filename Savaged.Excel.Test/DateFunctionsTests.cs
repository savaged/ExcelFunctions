namespace Savaged.Excel.Test
{
    public class DateFunctionsTests
    {
        [Fact]
        public void TestIsLeapYear()
        {
            Assert.False(DateFunctions.IsLeapYear(2023));
            Assert.True(DateFunctions.IsLeapYear(2024));
            Assert.False(DateFunctions.IsLeapYear(2025));
            Assert.False(DateFunctions.IsLeapYear(5));
            Assert.False(DateFunctions.IsLeapYear(-2023));
            Assert.False(DateFunctions.IsLeapYear(0));

            Assert.False(DateFunctions.IsWithinLeapYear(new DateTime(2022, 4, 6)));
            Assert.True(DateFunctions.IsWithinLeapYear(new DateTime(2023, 4, 6)));
            Assert.False(DateFunctions.IsWithinLeapYear(new DateTime(2024, 4, 6)));
            Assert.False(DateFunctions.IsWithinLeapYear(DateTime.MinValue));
            Assert.False(DateFunctions.IsWithinLeapYear(DateTime.MaxValue));
        }

        [Fact]
        public void TestDaysInYear()
        {
            Assert.Equal(365, DateFunctions.DaysInYear(2023));
            Assert.Equal(366, DateFunctions.DaysInYear(2024));
            Assert.Equal(365, DateFunctions.DaysInYear(2025));
            Assert.Equal(365, DateFunctions.DaysInYear(5));
            Assert.Equal(0, DateFunctions.DaysInYear(-2025));
            Assert.Equal(0, DateFunctions.DaysInYear(0));
        }

        [Fact]
        public void TestDaysInYearStarting()
        {
            Assert.Equal(365, DateFunctions.DaysInYearStarting(new DateTime(2022, 4, 6)));
            Assert.Equal(366, DateFunctions.DaysInYearStarting(new DateTime(2023, 4, 6)));
            Assert.Equal(365, DateFunctions.DaysInYearStarting(new DateTime(2024, 4, 6)));
            Assert.Equal(365, DateFunctions.DaysInYearStarting(new DateTime(9998, 12, 31)));
            Assert.Equal(365, DateFunctions.DaysInYearStarting(DateTime.MinValue));
            Assert.Equal(0, DateFunctions.DaysInYearStarting(new DateTime(9999, 1, 1)));
            Assert.Equal(0, DateFunctions.DaysInYearStarting(DateTime.MaxValue));
        }

        [Fact]
        public void TestAddYears()
        {
            Assert.Equal(new DateTime(2023, 4, 6), DateFunctions.AddYears(new DateTime(2022, 04, 06), 1));
        }

        [Fact]
        public void TestSubtractYears()
        {
            Assert.Equal(new DateTime(2022, 4, 6), DateFunctions.SubtractYears(new DateTime(2023, 04, 06), 1));
        }
    }
}