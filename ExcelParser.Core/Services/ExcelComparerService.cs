using ExcelParser.Common.Helpers;
using ExcelParser.Common.Validation.Contracts;
using ExcelParser.Core.Services.Contracts;
using ExcelParser.Domain.Entities;
using ExcelParser.Domain.Repository.Contracts;
using IronXL;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExcelParser.Core.Services
{
    // TODO Come up with different names
    public sealed class ExcelComparerService : IExcelComparerService
    {
        private readonly ISpreadsheetRepository _repository;
        private readonly IExcelValidator _validator;

        public ExcelComparerService(ISpreadsheetRepository repository, IExcelValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        // Keep track of changed cells in some kind of array
        public Task<OperationResult> CompareExcelDocument(IFormFile file)
             => Task.Factory.StartNew(() =>
             {
                 OperationResult result = _validator.ValidateExcelDocument(file);

                 if (result.Success)
                 {
                     List<Row> rowsFromDb = (List<Row>) _repository.GetAll();
                     
                     Worksheet worksheet = WorkBookHelper.ConvertFileToWorkbook(file);


                     SetRedColor();

                     workBook.SaveAs(file.FileName);
                 }

                 return result;
             });

        private void SetRedColor(Cell[] cells)
        {
            foreach (var cell in cells)
            {
                cell.Style.Font.Color = "#FF0000";
            }    
        }
    }
}
