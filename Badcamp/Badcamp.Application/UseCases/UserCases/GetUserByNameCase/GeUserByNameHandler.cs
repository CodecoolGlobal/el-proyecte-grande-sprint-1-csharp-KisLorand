using Badcamp.Application.Common;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases
{
    public class GeUserByNameHandler : IRequestHandler<GetUserByNameRequest, Response<User>>
    {
        UserStorage _userStorage;
        public GeUserByNameHandler(UserStorage userStorage)
        {
            _userStorage = userStorage;
        }
        public Response<User> Handle(GetUserByNameRequest message)
        {
            User user;
            try
            {
                user=_userStorage.GetUserByName(message.UserName);
                if(user==null)
                {
                    return Response.Fail<User>("user not found");
                }
                return Response.Ok(user);
            }
            catch (Exception e)
            {
                return Response.Fail<User>(e.Message);
               
            }
         
        }
    }
}
