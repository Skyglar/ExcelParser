using System.Collections.Generic;

namespace ExcelParser.Common.Helpers
{
    public sealed class ColumnValues
    {
        private static readonly List<string> _headerCells = new List<string>()
        {
            "Hie",
            "IDX",
            "Level",
            "Parent",
            "Node",
            "Description",
            "Method",
            "Contains_Att",
            "Contains_Val",
            "Between_Att",
            "Between_Lo",
            "Between_Hi"
        };

        private static readonly List<string> _letters = new List<string>()
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"
        };

        // TODO Think should these methods be a static
        public static List<string> GetHeaderList()
        {
            return new List<string>(_headerCells);
        }

        public static List<string> GetLettersList()
        {
            return new List<string>(_letters);
        }

        public static List<string> GetColumnAdresses(int rowIndex)
        {
            return new List<string>()
            {
                $"A{rowIndex}", $"B{rowIndex}", $"C{rowIndex}", $"D{rowIndex}", $"E{rowIndex}", $"F{rowIndex}", $"G{rowIndex}", $"H{rowIndex}", $"I{rowIndex}", $"J{rowIndex}", $"K{rowIndex}", $"L{rowIndex}"
            };
        }
    }
}
