using ExcelParser.Domain.Entities;
using IronXL;

namespace ExcelParser.Common.Helpers
{
    public class RowFactory
    {
        public static Row CreateRowFromCells(Cell[] cells, int index = 0)
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
