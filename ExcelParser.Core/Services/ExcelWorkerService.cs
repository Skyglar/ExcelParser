using ExcelParser.Common.Extensions;
using ExcelParser.Common.Helpers;
using ExcelParser.Common.ResponseBuilder;
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
    public sealed class ExcelWorkerService : IExcelWorkerService
    {
        private readonly ISpreadsheetRepository _spreadsheetRepository;
        private readonly IExcelValidator _excelValidator;

        /// <summary>
        ///     ctor()
        /// </summary>
        /// <param name="spreadsheetRepository"></param>
        /// <param name="excelValidator"></param>
        public ExcelWorkerService(ISpreadsheetRepository spreadsheetRepository, IExcelValidator excelValidator)
        {
            _spreadsheetRepository = spreadsheetRepository;
            _excelValidator = excelValidator;
        }

        public Task<IEnumerable<Row>> GetAllRows() =>
            Task.Factory.StartNew(() =>
            {
                return _spreadsheetRepository.GetAll();
            });

        public Task<OperationResult> AddRows(IFormFile file) =>
            Task.Factory.StartNew(() =>
            {
                OperationResult result = _excelValidator.ValidateExcelDocument(file);

                if (result.Success)
                {
                    WorkSheet worksheet = WorkBookHelper.ConvertFileToWorkbook(file).DefaultWorkSheet;

                    LinkedList<Row> rowList = worksheet.ToRowEntityList();

                    int effectedRowCount = _spreadsheetRepository.AddRange(rowList);
                    if (effectedRowCount < 1)
                    {
                        result.Success = false;
                        result.AddMessage(ResponseMessages.AddFailed);
                    }
                }

                return result;
            });

        public Task<OperationResult> UpdateRows(IFormFile file) =>
            Task.Factory.StartNew(() =>
            {
                OperationResult result = _excelValidator.ValidateExcelDocument(file);

                WorkSheet worksheet = WorkBookHelper.ConvertFileToWorkbook(file).DefaultWorkSheet;

                LinkedList<Row> rowList = worksheet.ToRowEntityList();

                if (result.Success)
                {
                    int effectedRowCount = _spreadsheetRepository.UpdateRange(rowList);

                    if (effectedRowCount < 1)
                    {
                        result.Success = false;
                        result.AddMessage(ResponseMessages.UpdateFailed);
                    }
                }

                return result;
            });

        public Task<OperationResult> DeleteRowById(int id) =>
            Task.Factory.StartNew(() =>
            {
                OperationResult result = new OperationResult();

                int effectedRow = _spreadsheetRepository.Delete(id);

                if (effectedRow < 1)
                {
                    result.Success = false;
                    result.AddMessage(ResponseMessages.DeleteFailed);
                    return result;
                }

                return result;
            });

        public Task<OperationResult> CreateExcelDocument(List<Row> rows) => 
            Task.Factory.StartNew(() =>
            {
                OperationResult result = new OperationResult();
                WorkBook workbook = new WorkbookBuilder().CreateWorkBook(rows);
                if (workbook == null)
                {
                    result.Success = false;
                    result.AddMessage(ResponseMessages.WorkBookError);
                    return result;
                }
                // TODO safe name of file
                workbook.SaveAs("example_workbook.xlsx");

                return result;
            });
    }
}
