using Microsoft.AspNetCore.Http;

namespace PCStore.BLL.Exceptions
{
    public class UnauthorizedAccessException : HttpException
    {
        public override int StatusCode => StatusCodes.Status401Unauthorized;

        public override string Message => "Authorization is required.";
    }
}