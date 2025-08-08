namespace BoneConnect.Services.CRUD.User.Abstraction;

public interface IUserUpdater
{
    Task UpdateUserAsync(string username, Models.Auth.User user);
}