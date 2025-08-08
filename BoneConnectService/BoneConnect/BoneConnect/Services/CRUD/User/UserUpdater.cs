using BoneConnect.Context;
using BoneConnect.Services.CRUD.User.Abstraction;

namespace BoneConnect.Services.CRUD.User;

public class UserUpdater() : IUserUpdater
{
    public async Task UpdateUserAsync(string username, Models.Auth.User user)
    {
        var context = CustomDbContext.Instance;
        await context.Users.RemoveAsync(username);
        await context.Users.InsertAsync(user.Username, user);
        await context.ConnectionGraph.EditVertexAsync(username, user.Username);
    }
}