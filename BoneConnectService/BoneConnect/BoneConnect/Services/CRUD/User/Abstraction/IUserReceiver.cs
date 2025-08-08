using System.Security.Claims;
using BoneConnect.DataStructures.List;

namespace BoneConnect.Services.CRUD.User.Abstraction;

public interface IUserReceiver
{
    Task<int> ReceiveAllUserCountAsync();
    Task<Models.Auth.User> ReceiveUserAsync(ClaimsPrincipal userClaims);
    Task<Models.Auth.User> ReceiveUserAsync(string username);
    Task<ArrayList<Models.Auth.User>> ReceiveAllUserAsync();
}