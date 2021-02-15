using ExcelParser.Common.Helpers;
using ExcelParser.Core.Services.Contracts;
using IronXL;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ExcelParser.Core.Services
{
    // TODO Come up with different names
    public sealed class ExcelComparerService : IExcelComparerService
    {
        public Task<OperationResult> CompareExcelDocument(IFormFile file)
             => Task.Factory.StartNew(() =>
             {
                 WorkBook workBook = WorkBook.FromStream(file.OpenReadStream());
                 SetRedColorDoChangedValues(workBook);

                 workBook.SaveAs(file.FileName);

                 return new OperationResult();
             });

        private void SetRedColorDoChangedValues(WorkBook workBook)
        {
            throw new NotImplementedException();
        }
    }
}
