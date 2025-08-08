using BoneConnect.Services;
using BoneConnect.Services.Abstraction;
using BoneConnect.Services.AuthServices;
using BoneConnect.Services.AuthServices.LoginService;
using BoneConnect.Services.AuthServices.LoginService.Abstraction;
using BoneConnect.Services.AuthServices.UserRegisterService;
using BoneConnect.Services.AuthServices.UserRegisterService.Abstraction;
using BoneConnect.Services.CRUD.Post;
using BoneConnect.Services.CRUD.Post.Abstraction;
using BoneConnect.Services.CRUD.User;
using BoneConnect.Services.CRUD.User.Abstraction;
using BoneConnect.Services.Post.PostCreateService;
using BoneConnect.Services.Post.PostCreateService.Abstraction;
using BoneConnect.Services.Post.PostDeleteService;
using BoneConnect.Services.Post.PostDeleteService.Abstraction;
using BoneConnect.Services.Post.PostInfoService;
using BoneConnect.Services.Post.PostInfoService.Abstraction;
using BoneConnect.Services.Post.PostUpdateInfoService;
using BoneConnect.Services.Post.PostUpdateInfoService.Abstraction;
using BoneConnect.Services.Suggestion;
using BoneConnect.Services.Suggestion.Abstraction;
using BoneConnect.Services.User.ConnectUserService;
using BoneConnect.Services.User.ConnectUserService.Abstraction;
using BoneConnect.Services.User.LogoutService;
using BoneConnect.Services.User.LogoutService.Abstraction;
using BoneConnect.Services.User.UserDeleteService;
using BoneConnect.Services.User.UserDeleteService.Abstraction;
using BoneConnect.Services.User.UserInfoService;
using BoneConnect.Services.User.UserInfoService.Abstraction;
using BoneConnect.Services.User.UserUpdateInfoService;
using BoneConnect.Services.User.UserUpdateInfoService.Abstraction;
using BoneConnect.Services.User.UserUpdatePasswordService;
using BoneConnect.Services.User.UserUpdatePasswordService.Abstraction;

namespace BoneConnect.Settings.Services;

public static class ServiceExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new ArrayListConverter<string>());
            });
        services.AddSingleton<ICookieSetter, CookieSetter>()
            .AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>()
            .AddSingleton<ILoginService, LoginService>()
            .AddSingleton<IPasswordHasher, CustomPasswordHasher>()
            .AddSingleton<IUserReceiver, UserReceiver>()
            .AddSingleton<IUserUpdater, UserUpdater>()
            .AddSingleton<IUserDeleter, UserDeleter>()
            .AddSingleton<IUserAdder, UserAdder>()
            .AddSingleton<IMessageResponseCreator, MessageResponseCreator>()
            .AddSingleton<IPasswordVerifier, PasswordVerifier>()
            .AddSingleton<IRegisterUserDtoMapper, RegisterUserDtoMapper>()
            .AddSingleton<IUserRegisterService, UserRegisterService>()
            .AddSingleton<IUserRegisterServiceValidator, UserRegisterServiceValidator>()
            .AddSingleton<IConnectionUserServiceValidator, ConnectionUserServiceValidator>()
            .AddSingleton<IConnectionUserService, ConnectionUserService>()
            .AddSingleton<ILogoutService, LogoutService>()
            .AddSingleton<IUserDeleteService, UserDeleteService>()
            .AddSingleton<IUserDeleteServiceValidator, UserDeleteServiceValidator>()
            .AddSingleton<IUserInfoService, UserInfoService>()
            .AddSingleton<IUserInfoServiceValidator, UserInfoServiceValidator>()
            .AddSingleton<IUserUpdateInfoService, UserUpdateInfoService>()
            .AddSingleton<IUserUpdateInfoServiceValidator, UserUpdateInfoServiceValidator>()
            .AddSingleton<IUserUpdatePasswordService, UserUpdatePasswordService>()
            .AddSingleton<IUserUpdatePasswordServiceValidator, UserUpdatePasswordServiceValidator>()
            .AddSingleton<IPostAdder, PostAdder>()
            .AddSingleton<IPostDeleter, PostDeleter>()
            .AddSingleton<IPostReceiver, PostReceiver>()
            .AddSingleton<IPostUpdater, PostUpdater>()
            .AddSingleton<ICreatePostDtoMapper, CreatePostDtoMapper>()
            .AddSingleton<IPostCreateServiceValidator, PostCreateServiceValidator>()
            .AddSingleton<IPostCreateService, PostCreateService>()
            .AddSingleton<IPostDeleteService, PostDeleteService>()
            .AddSingleton<IPostDeleteServiceValidator, PostDeleteServiceValidator>()
            .AddSingleton<IPostInfoService, PostInfoService>()
            .AddSingleton<IPostInfoServiceValidator, PostInfoServiceValidator>()
            .AddSingleton<IPostUpdateInfoService, PostUpdateInfoService>()
            .AddSingleton<IPostUpdateInfoServiceValidator, PostUpdateInfoServiceValidator>()
            .AddSingleton<IGraphSuggestionListCreator, GraphSuggestionListCreator>()
            .AddSingleton<ISuggestionListCreator, SuggestionListCreator>()
            .AddSingleton<ISuggestionService, SuggestionService>()
            .AddSingleton<ISuggestionServiceValidator, SuggestionServiceValidator>();
        return services;
    }
}