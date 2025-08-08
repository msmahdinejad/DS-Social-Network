namespace BoneConnect.Services.CRUD.Post.Abstraction;

public interface IPostAdder
{
    Task<Models.Post.Post> AddPostAsync(Models.Auth.User user, Models.Post.Post post);
}