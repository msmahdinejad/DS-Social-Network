namespace BoneConnect.Services.CRUD.Post.Abstraction;

public interface IPostDeleter
{
    Task DeletePostAsync(Models.Auth.User user, Models.Post.Post post);
}