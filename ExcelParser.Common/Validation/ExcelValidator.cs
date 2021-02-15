using ExcelParser.Common.Helpers;
using ExcelParser.Common.ResponseBuilder;
using ExcelParser.Common.Validation.Contracts;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ExcelParser.Common.Validation
{
    public sealed class ExcelValidator : IExcelValidator
    {
        public OperationResult ValidateExcelDocument(IFormFile file)
        {
            OperationResult result = new OperationResult();

            if (file == null)
            {
                result.Success = false;
                result.AddMessage(ResponseMessages.NoFile);
            }

            if (result.Success)
            {
                if (!IsFileExcelDocument(file))
                {
                    result.Success = false;
                    result.AddMessage(ResponseMessages.InvaliData);
                }
            }
            return result;
        }
        private bool IsFileExcelDocument(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();

            if (extension == ".XLS" || extension == ".XLSX")
            {
                return true;
            }
            return false;
        }
    }
}
