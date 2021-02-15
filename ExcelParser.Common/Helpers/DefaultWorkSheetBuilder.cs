using IronXL;

namespace ExcelParser.Common.Helpers
{
    public sealed class DefaultWorkSheetBuilder
    {
        public WorkSheet BuildDefaultWorkSheet(WorkBook workBook)
        {
            WorkSheet workSheet = workBook.DefaultWorkSheet;

            for (int i = 0; i < ColumnValues.GetHeaderList().Count; i++)
            {
                workSheet[ColumnValues.GetColumnAdresses(1)[i]].Value = ColumnValues.GetHeaderList()[i];
            }

            return workSheet;
        }
    }
}
