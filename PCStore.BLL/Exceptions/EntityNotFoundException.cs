using Microsoft.AspNetCore.Http;

namespace PCStore.BLL.Exceptions
{
    public class EntityNotFoundException : HttpException
    {
        public override int StatusCode => StatusCodes.Status404NotFound;

        public override string Message => "Entities not found!";
    }
}
