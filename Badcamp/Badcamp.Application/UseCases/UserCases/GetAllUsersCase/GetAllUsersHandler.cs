using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.UserCases.GetAllUsersCase
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, Response<IReadOnlyList<User>>>
    {
        UserStorage _userStorage;
        public GetAllUsersHandler(UserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public Response<IReadOnlyList<User>> Handle(GetAllUsersRequest message)
        {
            IReadOnlyList<User> users;
            try
            {
                users = _userStorage.GetAllUsers();
                if (users == null)
                {
                    return Response.Fail<IReadOnlyList<User>>("Events not found");
                }
                return Response.Ok(users);
            }
            catch (Exception e)
            {
                return Response.Fail<IReadOnlyList<User>>(e.Message);

            }

        }
    }
}
