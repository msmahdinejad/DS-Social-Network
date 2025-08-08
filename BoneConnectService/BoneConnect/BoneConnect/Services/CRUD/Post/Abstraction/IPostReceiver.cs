namespace BoneConnect.Services.CRUD.Post.Abstraction;

public interface IPostReceiver
{
    Task<Models.Post.Post> ReceivePostAsync(string id);
}