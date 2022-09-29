using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;

namespace Badcamp.Application.UseCases.UserCases.AddUser
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, Response<User>>
    {
        UserStorage _userStorage;
        public AddUserHandler(UserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public Response<User> Handle(AddUserRequest message)
        {
            User user = new User(message.UserName, message.Password, message.DateOfBirth, message.FullName);
            try
            {
                _userStorage.AddUser(user);
                return Response.Ok(user);
            }
            catch (Exception e)
            {
                return Response.Fail<User>(e.Message);

            }

        }
    }
}
