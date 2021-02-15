using IronXL;

namespace ExcelParser.Common.Helpers
{
    public sealed class DefaultWorkSheetBuilder
    {
        private readonly ColumnValues _columnValues;

        public DefaultWorkSheetBuilder()
        {
            _columnValues = new ColumnValues();
        }

        public WorkSheet BuildDefaultWorkSheet(WorkBook workBook)
        {
            WorkSheet workSheet = workBook.DefaultWorkSheet;

            for (int i = 0; i < _columnValues.HeaderCells.Count; i++)
            {
                workSheet[_columnValues.GetColumnAdresses(1)[i]].Value = _columnValues.HeaderCells[i];
            }

            return workSheet;
        }
    }
}
