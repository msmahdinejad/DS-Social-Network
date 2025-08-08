using BoneConnect.Context;
using BoneConnect.Models.Profile;
using BoneConnect.Services.CRUD.Post.Abstraction;

namespace BoneConnect.Services.CRUD.Post;

public class PostUpdater : IPostUpdater
{
    public async Task UpdatePostAsync(Models.Auth.User user, Models.Post.Post post)
    {
        var context = CustomDbContext.Instance;
        await context.Posts.EditAsync(post.Id, post);
        await user.posts.EditAsync(post.Id, new PostPreview(post));
    }
}