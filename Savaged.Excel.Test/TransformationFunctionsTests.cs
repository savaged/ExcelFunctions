namespace Savaged.Excel.Test
{
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

    }
}