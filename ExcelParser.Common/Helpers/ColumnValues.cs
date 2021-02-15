using System.Collections.Generic;

namespace ExcelParser.Common.Helpers
{
    public sealed class ColumnValues
    {
        public List<string> HeaderCells
        {
            get
            {
                return new List<string>()
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
            }
        }

        public List<string> GetColumnAdresses(int rowIndex)
        {
            return new List<string>()
            {
                $"A{rowIndex}", $"B{rowIndex}", $"C{rowIndex}", $"D{rowIndex}", $"E{rowIndex}", $"F{rowIndex}", $"G{rowIndex}", $"H{rowIndex}", $"I{rowIndex}", $"J{rowIndex}", $"K{rowIndex}", $"L{rowIndex}"
            };
        }
    }
}
