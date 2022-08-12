using System.Collections.Generic;
using Business.Configuration.Response;
using DTO.User;
using Models.Entities;

namespace Business.Abstract
{
    public interface IUserService
    {

        CommandResponse Register(CreateUserRegisterRequest register);
        CommandResponse Update(UpdateUserRequest register);
        CommandResponse Delete(DeleteUserRequest request);
        IEnumerable<User> GetAll();
        
    }
}
