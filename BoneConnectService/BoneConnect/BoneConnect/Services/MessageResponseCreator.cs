using BoneConnect.Dto;
using BoneConnect.Enums;
using BoneConnect.Services.Abstraction;

namespace BoneConnect.Services;

public class MessageResponseCreator : IMessageResponseCreator
{
    public ActionResponse<MessageDto> Create(StatusCodeType statusCodeType, string message)
    {
        return new ActionResponse<MessageDto>
        {
            StatusCode = statusCodeType,
            Data = new MessageDto(message)
        };
    }
}