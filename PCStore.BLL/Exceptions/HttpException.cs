using System;

namespace PCStore.BLL.Exceptions
{
    public abstract class HttpException : Exception
    {
        public abstract int StatusCode { get; }
    }
}
