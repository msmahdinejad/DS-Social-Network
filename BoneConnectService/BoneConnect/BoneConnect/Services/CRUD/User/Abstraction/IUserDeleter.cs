﻿namespace BoneConnect.Services.CRUD.User.Abstraction;

public interface IUserDeleter
{
    Task DeleteUserAsync(Models.Auth.User user);
}