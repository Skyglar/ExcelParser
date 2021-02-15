using ExcelParser.Common.Helpers;
using ExcelParser.Common.ResponseBuilder.Contracts;
using ExcelParser.Common.WebApi;
using ExcelParser.Common.WebApi.RoutingConfiguration;
using ExcelParser.Core.Services.Contracts;
using ExcelParser.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExcelParser.Core.Controllers
{
    [ApiController]
    [AssignControllerRoute(WebApiEnvironmnet.Current, WebApiVersion.ApiVersion1, ApplicationSegments.Excel)]
    public class SpreadsheetController : WebApiControllerBase
    {
        private readonly IExcelWorkerService _excelService;

        /// <summary>
        ///     ctor()
        /// </summary>
        /// <param name="rowService"></param>
        public SpreadsheetController(IExcelWorkerService rowService, IResponseFactory responseFactory)
            : base(responseFactory)
        {
            _excelService = rowService;
        }

        [HttpGet]
        [AssignActionRoute(ExcelSegment.GetExcel)]
        public async Task<ActionResult> GetExcel()
        {
            try
            {
                return Ok(SuccessResponseBody((List<Row>)await _excelService.GetAllRows()));
            }
            catch (System.Exception exc)
            {
                return BadRequest(ErrorResponseBody(exc.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }

        [HttpPost]
        [AssignActionRoute(ExcelSegment.AddRows)]
        public async Task<ActionResult> AddRows(IFormFile file)
        {
            try
            {
                OperationResult result = await _excelService.AddRows(file);
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

        [HttpPut]
        [AssignActionRoute(ExcelSegment.Update)]
        public async Task<ActionResult> UpdateSpreadsheet(IFormFile file)
        {
            try
            {
                OperationResult result = await _excelService.UpdateRows(file);
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

        [HttpDelete]
        [AssignActionRoute(ExcelSegment.DeleteRow)]
        public async Task<ActionResult> DeleteRowById([FromQuery] int rowId)
        {
            try
            {
                OperationResult result = await _excelService.DeleteRowById(rowId);
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
