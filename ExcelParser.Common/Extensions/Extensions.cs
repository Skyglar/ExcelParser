using ExcelParser.Common.Helpers;
using ExcelParser.Domain.Entities;
using IronXL;
using System.Collections.Generic;
using System.Linq;

namespace ExcelParser.Common.Extensions
{
    public static class Extensions
    {
        public static LinkedList<Row> ToRowEntityList(this WorkSheet worksheet)
        {
            LinkedList<Row> rowList = new LinkedList<Row>();
            for (int i = 1; i < worksheet.RowCount; i++)
            {
                RangeRow row = worksheet.GetRow(i);
                rowList.AddLast(RowFactory.CreateRowFromCells(row.ToArray()));
            }
            return rowList;
        }
    }
}
