using ExcelParser.Common.Helpers;
using ExcelParser.Domain.Entities;
using IronXL;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ExcelParser.Common.Extentions
{
    public static class Extentions
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

        public static bool CompareCells(this Cell cell, Cell cmpCell)
        {
            return cell.ToString().Equals(cmpCell.ToString());
        }
    }
}
