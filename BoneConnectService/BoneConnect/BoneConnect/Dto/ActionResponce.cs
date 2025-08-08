using BoneConnect.Enums;

namespace BoneConnect.Dto;

public class ActionResponse<T>
{
    public ActionResponse()
    {
        StatusCode = StatusCodeType.Success;
    }

    public T Data { get; set; }

    public StatusCodeType StatusCode { get; set; }
}