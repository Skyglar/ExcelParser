using ExcelParser.Common.Helpers;
using ExcelParser.Domain.Entities;
using IronXL;
using System.Collections.Generic;
using System.Linq;

namespace ExcelParser.Common.Extentions
{
    public static class Extentions
    {
        public static LinkedList<Row> ToRowEntityList(this WorkSheet worksheet)
        {
            LinkedList<Row> rowList = new LinkedList<Row>();
            for (int i = 0; i < worksheet.RowCount; i++)
            {
                RangeRow row = worksheet.GetRow(i);
                rowList.Append(RowFactory.CreateRowFromCells(row.ToArray()));
            }
            return rowList;
        }
    }
}
