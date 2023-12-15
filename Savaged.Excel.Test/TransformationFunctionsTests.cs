namespace Savaged.Excel.Test;

public class TransformationFunctionsTests
{
    private const string STORE = "Alpha (Demo) | 379";
    private const string STORE_UID = "QWxwaGEgKERlbW8pIHwgMzc5";
    private const string SCHEME = "Sheffield | Meadowhall Shopping Centre";
    private const string SCHEME_UID = "U2hlZmZpZWxkIHwgTWVhZG93aGFsbCBTaG9wcGluZyBDZW50cmU=";

    [Fact]
    public void TestToUniqueIdentifier()
    {
        Assert.Equal(STORE_UID, STORE.ToUniqueIdentifier());
        Assert.Equal(SCHEME_UID, SCHEME.ToUniqueIdentifier());
    }

    [Fact]
    public void TestFromUniqueIdentifier()
    {
        Assert.Equal(STORE, STORE_UID.FromUniqueIdentifier());
        Assert.Equal(SCHEME, SCHEME_UID.FromUniqueIdentifier());
    }

    [Fact]
    public void TestPad()
    {
        Assert.Equal("007", 7.Pad(3, '0', false));
        Assert.Equal("070", 70.Pad(3, '0', false));

        Assert.Equal("06.9", 6.9.PadNumberWithDecimalPlaces(4, '0', false));

        Assert.Equal("007", (-7).Pad(3, '0', false));
        Assert.Equal("06.9", (-6.9).PadNumberWithDecimalPlaces(4, '0', false));

        Assert.Equal("300", 3.Pad(3, '0', true));
        Assert.Equal("2.90", 2.9.PadNumberWithDecimalPlaces(4, '0', true));

        Assert.Equal("X5", 5.Pad(2, 'X', false));
        Assert.Equal("5X", 5.Pad(2, 'X', true));
    }

}
