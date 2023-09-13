namespace Savaged.Excel.Test;

public class MathFunctionsTests
{
    [Fact]
    public void TestMultiplyMatrices()
    {
        double[,] lhs = { { 1d, 4d, 2d }, { 3d, 6d, 8d } };
        double[,] rhs = { { 4d, 2d, 1d }, { 6d, 5d, 3d } };
        Assert.Equal(ExcelError.ExcelErrorValue, MathFunctions.MultiplyMatrices(lhs, rhs));

        lhs = new double[,] { { 1d, 4d }, { 3d, 6d } };
        rhs = new double[,] { { 4d, 2d, 8d }, { 6d, 5d, 7d } };
        double[,] expectation = { { 28d, 22d, 36d }, { 48d , 36d, 66d } };
        var result = MathFunctions.MultiplyMatrices(lhs, rhs);
        Assert.Equal(expectation, result);
    }
}
