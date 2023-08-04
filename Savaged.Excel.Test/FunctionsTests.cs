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
        }

        [Fact]
        public void TestDaysInYear()
        {
            Assert.Equal(365, Functions.DaysInYear(2023));
            Assert.Equal(366, Functions.DaysInYear(2024));
            Assert.Equal(365, Functions.DaysInYear(2025));
        }

        [Fact]
        public void TestDaysInYearStarting()
        {
            Assert.Equal(365, Functions.DaysInYearStarting(new DateTime(2022, 4, 6)));
            Assert.Equal(366, Functions.DaysInYearStarting(new DateTime(2023, 4, 6)));
            Assert.Equal(365, Functions.DaysInYearStarting(new DateTime(2024, 4, 6)));
        }
    }
}