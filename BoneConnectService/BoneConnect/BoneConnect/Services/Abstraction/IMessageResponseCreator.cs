using BoneConnect.Dto;
using BoneConnect.Enums;

namespace BoneConnect.Services.Abstraction;

public interface IMessageResponseCreator
{
    ActionResponse<MessageDto> Create(StatusCodeType statusCodeType, string message);
}