using BoneConnect.Context;
using BoneConnect.Services.CRUD.Post.Abstraction;

namespace BoneConnect.Services.CRUD.Post;

public class PostReceiver : IPostReceiver
{
    public async Task<Models.Post.Post> ReceivePostAsync(string id)
    {
        var context = CustomDbContext.Instance;
        var post = await context.Posts.GetAsync(id);
        return post;
    }
}