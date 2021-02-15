using ExcelParser.Common.WebApi;
using ExcelParser.Common.WebApi.RoutingConfiguration;
using ExcelParser.Core.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExcelParser.Core.Controllers
{
    [ApiController]
    [AssignControllerRoute(WebApiEnvironmnet.Current, WebApiVersion.ApiVersion1, ApplicationSegments.ExcelValidation)]
    public class ExcelValidationController : ControllerBase
    {
        private readonly IExcelWorkerService _excelService;

        public ExcelValidationController(IExcelWorkerService excelService)
        {
            _excelService = excelService;
        }

        [HttpGet]
        [AssignActionRoute(ExcelSegment.ValidateExcel)]
        public async Task<ActionResult> Get()
        {
            return Ok();
        }

        [HttpPost]
        [AssignActionRoute(ExcelSegment.ValidateExcel)]
        public async Task<ActionResult> Validate(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest(new { value = "No file was send" });
            }


            return Ok();
        }
    }
}
