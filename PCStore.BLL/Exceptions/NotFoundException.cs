using Microsoft.AspNetCore.Http;

namespace PCStore.BLL.Exceptions
{
    public class NotFoundException : HttpException
    {
        public override int StatusCode => StatusCodes.Status404NotFound;

        public override string Message => "The requested resource was not found.";
    }
}