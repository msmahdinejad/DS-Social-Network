using BoneConnect.Context;
using BoneConnect.Dto;
using BoneConnect.Dto.User;
using BoneConnect.Enums;
using BoneConnect.Models.Profile;
using BoneConnect.Services.CRUD.User.Abstraction;
using BoneConnect.Services.User.ConnectUserService.Abstraction;

namespace BoneConnect.Services.User.ConnectUserService;

public class ConnectionUserService(IConnectionUserServiceValidator validator) : IConnectionUserService
{
    public async Task<ActionResponse<MessageDto>> Connection(Models.Auth.User currentUser, Models.Auth.User secondUser)
    {
        var validateResult = await validator.ValidateConnection(currentUser, secondUser);
        if (validateResult.StatusCode != StatusCodeType.Success)
            return validateResult;

        await Connect(currentUser, secondUser);

        return validateResult;
    }

    public async Task<ActionResponse<MessageDto>> RemoveConnection(Models.Auth.User currentUser, Models.Auth.User secondUser)
    {
        var validateResult = await validator.ValidateRemoveConnection(currentUser, secondUser);
        if (validateResult.StatusCode != StatusCodeType.Success)
            return validateResult;

        await DisConnect(currentUser, secondUser);

        return validateResult;
    }
    
    private async Task Connect(Models.Auth.User currentUser, Models.Auth.User secondUser)
    {
        await currentUser.connections.InsertAsync(secondUser.Username, new UserPreview(secondUser));
        await secondUser.connections.InsertAsync(currentUser.Username, new UserPreview(currentUser));
        var context = CustomDbContext.Instance;
        await context.ConnectionGraph.AddEdgeAsync(currentUser.Username, secondUser.Username);

        //await userUpdater.UpdateUserAsync(id, user);
    }
    
    private async Task DisConnect(Models.Auth.User currentUser, Models.Auth.User secondUser)
    {
        await currentUser.connections.RemoveAsync(secondUser.Username);
        await secondUser.connections.RemoveAsync(currentUser.Username);
        var context = CustomDbContext.Instance;
        await context.ConnectionGraph.RemoveEdgeAsync(currentUser.Username, secondUser.Username);
        
        //await userUpdater.UpdateUserAsync(id, user);
    }
}