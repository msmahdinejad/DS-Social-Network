using BoneConnect.Context;
using BoneConnect.Models.Profile;
using BoneConnect.Services.CRUD.Post.Abstraction;

namespace BoneConnect.Services.CRUD.Post;

public class PostAdder : IPostAdder
{
    public async Task<Models.Post.Post> AddPostAsync(Models.Auth.User user, Models.Post.Post post)
    {
        var context = CustomDbContext.Instance;
        await context.Posts.InsertAsync(post.Id, post);
        await user.posts.InsertAsync(post.Id, new PostPreview(post));
        return post;
    }
}