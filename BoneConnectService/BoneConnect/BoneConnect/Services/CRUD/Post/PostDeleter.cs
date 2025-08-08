using BoneConnect.Context;
using BoneConnect.Services.CRUD.Post.Abstraction;

namespace BoneConnect.Services.CRUD.Post;

public class PostDeleter : IPostDeleter
{
    public async Task DeletePostAsync(Models.Auth.User user, Models.Post.Post post)
    {
        var context = CustomDbContext.Instance;
        await context.Posts.RemoveAsync(post.Id);
        await user.posts.RemoveAsync(post.Id);
    }
}