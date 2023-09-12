namespace Savaged.Excel;

public static class MathFunctions
{
    [ExcelFunction(Description = "Perform matrix multiplucation.")]
    public static object MultiplyMatrices(
        [ExcelArgument(Description = "Input matrix range")] double[,] firstMatrix,
        [ExcelArgument(Description = "Input matrix range")] double[,] secondMatrix)
    {
        if (firstMatrix is null || secondMatrix is null)
            return ExcelError.ExcelErrorValue;

        var firstRowCount = firstMatrix.GetLength(0);
        var firstColumnCount = firstMatrix.GetLength(1);
        var secondRowCount = secondMatrix.GetLength(0);
        var secondColumnCount = secondMatrix.GetLength(1);

        if (firstColumnCount != secondRowCount)
            return ExcelError.ExcelErrorValue;

        var value = new double[firstRowCount, secondColumnCount];
        for (int i = 0; i < firstRowCount; i++)
        {
            for (int j = 0; j < secondColumnCount; j++)
            {
                var d = 0d;
                for (int k = 0; k < firstColumnCount; k++)
                    d += firstMatrix[i, k] * secondMatrix[k, j];

                value[i, j] = d;
            }
        }
        return value;
    }
}
