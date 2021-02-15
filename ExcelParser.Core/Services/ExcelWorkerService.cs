using ExcelParser.Common.Extentions;
using ExcelParser.Common.Helpers;
using ExcelParser.Common.ResponseBuilder;
using ExcelParser.Common.Validation.Contracts;
using ExcelParser.Core.Services.Contracts;
using ExcelParser.Domain.Entities;
using ExcelParser.Domain.Repository.Contracts;
using IronXL;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
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

        // TODO Refactor method
        public Task<OperationResult> CreateExcelDocument(List<Row> rows)
            => Task.Factory.StartNew(() =>
            {
                WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
                WorkSheet worksheet = new DefaultWorkSheetBuilder().BuildDefaultWorkSheet(workbook);

                for (int i = 0, j = 2; i < rows.Count; i++, j++)
                {
                    //var columnIndexes = ColumnValues.GetColumnAdresses(j);

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

                // TODO safe name of file
                workbook.SaveAs("example_workbook.xlsx");

                return new OperationResult();
            });
    }
}
