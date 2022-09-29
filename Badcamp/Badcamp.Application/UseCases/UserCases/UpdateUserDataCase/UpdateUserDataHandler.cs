using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;

namespace Badcamp.Application.UseCases.UserCases.UpdateUserDataCase
{
    public class UpdateUserDataHandler : IRequestHandler<UpdateUserDataRequest, Response<User>>
    {
        UserStorage _userStorage;
        public UpdateUserDataHandler(UserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public Response<User> Handle(UpdateUserDataRequest message)
        {
            User user = message.UpdatedUser;
            try
            {                
                _userStorage.UpdateUserData(message.UserName, message.UpdatedUser);
                return Response.Ok(user);
            }
            catch (Exception e)
            {
                return Response.Fail<User>(e.Message);

            }

        }
  
    }
}
