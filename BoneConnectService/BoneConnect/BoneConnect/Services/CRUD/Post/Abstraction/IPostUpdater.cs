namespace BoneConnect.Services.CRUD.Post.Abstraction;

public interface IPostUpdater
{
    Task UpdatePostAsync(Models.Auth.User user, Models.Post.Post post);
}