using ExcelParser.Common.Helpers;
using Microsoft.AspNetCore.Http;

namespace ExcelParser.Common.Validation.Contracts
{
    public interface IExcelValidator
    {
        OperationResult ValidateExcelDocument(IFormFile file);
    }
}
