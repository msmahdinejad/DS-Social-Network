using BoneConnect.Context;
using BoneConnect.Services.CRUD.User.Abstraction;

namespace BoneConnect.Services.CRUD.User;

public class UserDeleter() : IUserDeleter
{
    public async Task DeleteUserAsync(Models.Auth.User user)
    {
        var context = CustomDbContext.Instance;
        await context.Users.RemoveAsync(user.Username);
        await context.ConnectionGraph.RemoveVertexAsync(user.Username);
    }
}