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
                rowList.Append(CreateRowModel(row.ToArray()));
            }
            return rowList;
        }

        // TODO Move this method somewhere else
        private static Row CreateRowModel(Cell[] cells, int index = 0)
        {
            return new Row()
            {
                Hie = cells[index++].StringValue,
                IDX = cells[index++].IntValue,
                Level = cells[index++].IntValue,
                Parent = cells[index++].StringValue,
                Node = cells[index++].StringValue,
                Description = cells[index++].StringValue,
                Method = cells[index++].StringValue,
                Contains_Att = cells[index++].StringValue,
                Contains_Val = cells[index++].StringValue,
                Between_Att = cells[index++].StringValue,
                Between_Lo = cells[index++].DecimalValue,
                Between_Hi = cells[index++].DecimalValue
            };
        }
    }
}
