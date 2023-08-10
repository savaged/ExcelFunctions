namespace Savaged.Excel.Test
{
    public class FunctionsTests
    {
        [Fact]
        public void TestIsLeapYear()
        {
            Assert.False(Functions.IsLeapYear(2023));
            Assert.True(Functions.IsLeapYear(2024));
            Assert.False(Functions.IsLeapYear(2025));
            Assert.False(Functions.IsLeapYear(5));
            Assert.False(Functions.IsLeapYear(-2023));
            Assert.False(Functions.IsLeapYear(0));

            Assert.False(Functions.IsWithinLeapYear(new DateTime(2022, 4, 6)));
            Assert.True(Functions.IsWithinLeapYear(new DateTime(2023, 4, 6)));
            Assert.False(Functions.IsWithinLeapYear(new DateTime(2024, 4, 6)));
            Assert.False(Functions.IsWithinLeapYear(DateTime.MinValue));
            Assert.False(Functions.IsWithinLeapYear(DateTime.MaxValue));
        }

        [Fact]
        public void TestDaysInYear()
        {
            Assert.Equal(365, Functions.DaysInYear(2023));
            Assert.Equal(366, Functions.DaysInYear(2024));
            Assert.Equal(365, Functions.DaysInYear(2025));
            Assert.Equal(365, Functions.DaysInYear(5));
            Assert.Equal(0, Functions.DaysInYear(-2025));
            Assert.Equal(0, Functions.DaysInYear(0));
        }

        [Fact]
        public void TestDaysInYearStarting()
        {
            Assert.Equal(365, Functions.DaysInYearStarting(new DateTime(2022, 4, 6)));
            Assert.Equal(366, Functions.DaysInYearStarting(new DateTime(2023, 4, 6)));
            Assert.Equal(365, Functions.DaysInYearStarting(new DateTime(2024, 4, 6)));
            Assert.Equal(365, Functions.DaysInYearStarting(new DateTime(9998, 12, 31)));
            Assert.Equal(365, Functions.DaysInYearStarting(DateTime.MinValue));
            Assert.Equal(0, Functions.DaysInYearStarting(new DateTime(9999, 1, 1)));
            Assert.Equal(0, Functions.DaysInYearStarting(DateTime.MaxValue));
        }
    }
}