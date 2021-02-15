using IronXL;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ExcelParser.Common.Helpers
{
    public sealed class WorkBookHelper
    {
        public static WorkBook ConvertFileToWorkbook(IFormFile file)
        {
            WorkBook workBook;
            using (Stream stream = file.OpenReadStream())
            {
                workBook = WorkBook.FromStream(stream);
            }

            return workBook;
        }
    }
}
