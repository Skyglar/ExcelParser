using ExcelParser.Domain.Entities;
using IronXL;

namespace ExcelParser.Common.Helpers
{
    public class RowFactory
    {
        public static Row CreateRowFromCells(Cell[] cells, int index = 0)
        {
            Row row = new Row();
            row.Hie = cells[index++].StringValue;
            row.IDX = cells[index++].IntValue;
            row.Level = cells[index++].IntValue;
            row.Parent = cells[index++].StringValue;
            row.Node = cells[index++].StringValue;
            row.Description = cells[index++].StringValue;
            try
            {
                row.Method = cells[index++].StringValue;
            }
            catch (System.Exception)
            {
                row.Method = "Contains";
            }
            row.Contains_Att = cells[index++].StringValue;
            row.Contains_Val = cells[index++].StringValue;
            row.Between_Att = cells[index++].StringValue;
            row.Between_Lo = cells[index++].DecimalValue;
            row.Between_Hi = cells[index++].DecimalValue;

            return row;
        }
    }
}
