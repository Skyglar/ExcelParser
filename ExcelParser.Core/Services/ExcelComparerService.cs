using ExcelParser.Common.Helpers;
using ExcelParser.Common.Validation.Contracts;
using ExcelParser.Core.Services.Contracts;
using ExcelParser.Domain.Entities;
using ExcelParser.Domain.Repository.Contracts;
using IronXL;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelParser.Core.Services
{
    public sealed class ExcelComparerService : IExcelComparerService
    {
        private readonly ISpreadsheetRepository _repository;
        private readonly IExcelValidator _validator;

        public ExcelComparerService(ISpreadsheetRepository repository, IExcelValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public Task<OperationResult> CompareExcelDocument(IFormFile file) =>
             Task.Factory.StartNew(() =>
             {
                 OperationResult result = _validator.ValidateExcelDocument(file);

                 if (result.Success)
                 {
                     WorkBook workBook = WorkBookHelper.ConvertFileToWorkbook(file);
                     WorkSheet worksheet = workBook.DefaultWorkSheet;

                     List<Row> rowsFromDb = (List<Row>)_repository.GetAll();
                     WorkSheet dbWorksheet = new WorkbookBuilder().CreateWorkBook(rowsFromDb).DefaultWorkSheet;

                     List<Cell> changedCells = (List<Cell>)FindChangedCells(worksheet, dbWorksheet);
                     SetRedColor(changedCells);

                     workBook.SaveAs(file.FileName);
                 }

                 return result;
             });

        private void SetRedColor(List<Cell> cells)
        {
            foreach (var cell in cells)
            {
                cell.Style.Font.Color = "#FF0000";
            }
        }

        private IEnumerable<Cell> FindChangedCells(WorkSheet currentWorksheet, WorkSheet dbWorksheet)
        {
            List<Cell> result = new List<Cell>();
            for (int i = 2; i < currentWorksheet.RowCount; i++)
            {
                Range currentCells = currentWorksheet[$"A{i}:L{i}"];
                Range dbCells = dbWorksheet[$"A{i}:L{i}"];

                var allData = currentCells.Concat(dbCells);

                try
                {
                    var uniqueTest = allData
                        .GroupBy(cell => cell.Value)
                        .Where(group => group.Count() == 1)
                        .Select(group => group.Single());

                    result.AddRange(uniqueTest);
                }
                catch (System.Exception)
                {
                    continue;
                }
            }

            return result;
        }
    }
}
