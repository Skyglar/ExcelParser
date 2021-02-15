using ExcelParser.Common.ResponseBuilder.Contracts;

namespace ExcelParser.Common.ResponseBuilder
{
    public class ResponseFactory : IResponseFactory
    {
        public IWebResponse GetSuccessReponse()
        {
            return new SuccessResponse();
        }

        IWebResponse IResponseFactory.GetErrorResponse()
        {
            return new ErrorResponse();
        }
    }
}
