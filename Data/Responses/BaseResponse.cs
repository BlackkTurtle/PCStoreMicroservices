using PCStore.Data.Responses.Enums;
using PCStore.Data.Responses.Interfaces;

namespace PCStore.Data.Responses;

public class BaseResponse<T> : IBaseResponse<T>
{
    public string Description { get; set; } = null!;
    public StatusCode StatusCode { get; set; }
    public int ResultsCount { get; set; }
    public T? Data { get; set; }
}