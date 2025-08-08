using BoneConnect.Dto;
using BoneConnect.Dto.Post;
using BoneConnect.Dto.User;

namespace BoneConnect.Services.Post.PostInfoService.Abstraction;

public interface IPostInfoService
{
    Task<ActionResponse<PostOutputInfoDto>> GetPost(Models.Post.Post post);

}