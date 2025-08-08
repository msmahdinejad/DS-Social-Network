using BoneConnect.Dto;
using BoneConnect.Dto.Auth;
using BoneConnect.Enums;
using BoneConnect.Services.AuthServices.UserRegisterService.Abstraction;
using BoneConnect.Services.CRUD.User.Abstraction;

namespace BoneConnect.Services.AuthServices.UserRegisterService;

public class UserRegisterService(
    IRegisterUserDtoMapper mapper,
    IUserAdder userAdder,
    IUserRegisterServiceValidator validator) : IUserRegisterService
{
    public async Task<ActionResponse<MessageDto>> RegisterUser(RegisterUserDto registerUserDto)
    {
        var validateResult = await validator.Validate(registerUserDto);
        if (validateResult.StatusCode != StatusCodeType.Success) return validateResult;

        await AddUser(registerUserDto);

        return validateResult;
    }

    private async Task AddUser(RegisterUserDto createUserDto)
    {
        var user = mapper.Map(createUserDto);
        await userAdder.AddUserAsync(user);
    }
}