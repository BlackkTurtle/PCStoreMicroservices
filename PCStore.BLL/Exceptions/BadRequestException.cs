﻿using Microsoft.AspNetCore.Http;

namespace PCStore.BLL.Exceptions
{
    public class BadRequestException : HttpException
    {
        public override int StatusCode => StatusCodes.Status400BadRequest;

        public override string Message => "The request is invalid.";
    }
}