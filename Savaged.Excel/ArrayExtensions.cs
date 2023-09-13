namespace Savaged.Excel;

public static class ArrayExtensions
{
    public static Span<T> GetRowSpan<T>(this T[,] array, int rowIndex)
    {
        if (array is null)
            throw new ArgumentNullException(nameof(array));

        if (rowIndex < 0 || rowIndex >= array.GetLength(0))
            throw new ArgumentOutOfRangeException(nameof(rowIndex));

        int columns = array.GetLength(1);
        T[] rowData = new T[columns];

        for (int i = 0; i < columns; i++)
            rowData[i] = array[rowIndex, i];

        return new Span<T>(rowData);
    }

    public static Span<T> GetColumnSpan<T>(this T[,] array, int columnIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));

        if (columnIndex < 0 || columnIndex >= array.GetLength(1))
            throw new ArgumentOutOfRangeException(nameof(columnIndex));

        int rowCount = array.GetLength(0);
        T[] columnData = new T[rowCount];

        for (int i = 0; i < rowCount; i++)
            columnData[i] = array[i, columnIndex];

        return new Span<T>(columnData);
    }


}
