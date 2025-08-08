using BoneConnect.Context;
using BoneConnect.Services.CRUD.User.Abstraction;

namespace BoneConnect.Services.CRUD.User;

public class UserAdder() : IUserAdder
{
    public async Task<Models.Auth.User> AddUserAsync(Models.Auth.User user)
    {
        var context = CustomDbContext.Instance;
        await context.Users.InsertAsync(user.Username, user);
        await context.ConnectionGraph.AddVertexAsync(user.Username);
        return user;
    }
}