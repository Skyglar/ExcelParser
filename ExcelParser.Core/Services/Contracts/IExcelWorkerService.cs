using ExcelParser.Common.Helpers;
using ExcelParser.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExcelParser.Core.Services.Contracts
{
    public interface IExcelWorkerService
    {
        Task<IEnumerable<Row>> GetAllRows();
        Task<OperationResult> AddRows(IFormFile file);
        Task<OperationResult> UpdateRows(IFormFile file);
        Task<OperationResult> DeleteRowById(int id);
        Task<OperationResult> CreateExcelDocument(List<Row> rows);
    }
}
