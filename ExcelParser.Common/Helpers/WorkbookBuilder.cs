using ExcelParser.Domain.Entities;
using IronXL;
using System.Collections.Generic;

namespace ExcelParser.Common.Helpers
{
    public sealed class WorkbookBuilder
    {
        public WorkBook CreateWorkBook(List<Row> rows)
        {
            WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
            WorkSheet worksheet = new DefaultWorkSheetBuilder().BuildDefaultWorkSheet(workbook);

            for (int i = 0, j = 2; i < rows.Count; i++, j++)
            {
                worksheet[$"A{j}"].Value = rows[i].Hie;
                worksheet[$"B{j}"].Value = rows[i].IDX;
                worksheet[$"C{j}"].Value = rows[i].Level;
                worksheet[$"D{j}"].Value = rows[i].Parent;
                worksheet[$"E{j}"].Value = rows[i].Node;
                worksheet[$"F{j}"].Value = rows[i].Description;
                worksheet[$"G{j}"].Value = rows[i].Method;
                worksheet[$"H{j}"].Value = rows[i].Contains_Att;
                worksheet[$"I{j}"].Value = rows[i].Contains_Val;
                worksheet[$"J{j}"].Value = rows[i].Between_Att;
                worksheet[$"K{j}"].Value = rows[i].Between_Lo;
                worksheet[$"L{j}"].Value = rows[i].Between_Hi;
            }

            return workbook;
        }
    }
}
