using ExcelParser.Common.Helpers;
using ExcelParser.Common.ResponseBuilder.Contracts;
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
    public class ExcelValidationController : WebApiControllerBase
    {
        private readonly IExcelComparerService _excelComparerService;

        public ExcelValidationController(IExcelComparerService excelComparerService, IResponseFactory responseFactory)
            : base(responseFactory)
        {
            _excelComparerService = excelComparerService;
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
            try
            {
                OperationResult result = await _excelComparerService.CompareExcelDocument(file);
                if (result.Success)
                {
                    return Ok(SuccessResponseBody(result));
                }
                return BadRequest(ErrorResponseBody(result.MessageList.ToString(), System.Net.HttpStatusCode.BadRequest));
            }
            catch (System.Exception exc)
            {
                return BadRequest(ErrorResponseBody(exc.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
    }
}
