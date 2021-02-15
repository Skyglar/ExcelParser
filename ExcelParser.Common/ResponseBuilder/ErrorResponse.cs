﻿using ExcelParser.Common.ResponseBuilder.Contracts;
using System.Net;

namespace ExcelParser.Common.ResponseBuilder
{
    public class ErrorResponse : IWebResponse
    {
        public object Body { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
