using Microsoft.AspNetCore.Http;

namespace PCStore.BLL.Exceptions
{
    public class ForbiddenAccessException : HttpException
    {
        public override int StatusCode => StatusCodes.Status403Forbidden;
        public override string Message => "Forbidden access";
    }
}
