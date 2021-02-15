using ExcelParser.Common.Helpers;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ExcelParser.Core.Services.Contracts
{
    public interface IExcelComparerService
    {
        Task<OperationResult> CompareExcelDocument(IFormFile file);
    }
}
