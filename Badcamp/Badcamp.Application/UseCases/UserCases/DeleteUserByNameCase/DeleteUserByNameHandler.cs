using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.UserCases.DeleteUserCase
{
    public class DeleteUserByNameHandler : IRequestHandler<DeleteUserByNameRequest, Response<User>>
    {
        UserStorage _userStorage;
        public DeleteUserByNameHandler(UserStorage userStorage)
        {
            _userStorage = userStorage;
        }
        public Response<User> Handle(DeleteUserByNameRequest message)
        {
            User user = _userStorage.GetUserByName(message.UserName);
            try
            {                
                if (user == null)
                {
                    return Response.Fail<User>("User does not exist!");
                }
                _userStorage.DeleteUser(user);
                return Response.Ok(user);
            }
            catch (Exception e)
            {
                return Response.Fail<User>(e.Message);
            }
        }
    }
}
