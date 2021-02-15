
namespace ExcelParser.Common.Extentions
{
    public static class StringExtentions
    {
        public static decimal? ToNullableDecimal(this string str)
        {
            if (decimal.TryParse(str, out decimal value)) return value;

            return null;
        }
    }
}
