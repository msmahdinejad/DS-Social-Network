using System.Security.Claims;
using BoneConnect.Context;
using BoneConnect.DataStructures.List;
using BoneConnect.Services.CRUD.User.Abstraction;

namespace BoneConnect.Services.CRUD.User;

public class UserReceiver() : IUserReceiver
{
    public async Task<int> ReceiveAllUserCountAsync()
    {
        var context = CustomDbContext.Instance;
        var users = await context.Users.GetAllAsync();
        return users.Count;
    }

    public async Task<Models.Auth.User> ReceiveUserAsync(ClaimsPrincipal userClaims)
    {
        var username = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var context = CustomDbContext.Instance;
        var user = await context.Users.GetAsync(username);
        return user;
    }

    public async Task<Models.Auth.User> ReceiveUserAsync(string username)
    {
        var context = CustomDbContext.Instance;
        var user = await context.Users.GetAsync(username);
        return user;
    }

    public async Task<ArrayList<Models.Auth.User>> ReceiveAllUserAsync()
    {
        var context = CustomDbContext.Instance;
        var users = await context.Users.GetAllValuesAsync();
        return users;
    }
}