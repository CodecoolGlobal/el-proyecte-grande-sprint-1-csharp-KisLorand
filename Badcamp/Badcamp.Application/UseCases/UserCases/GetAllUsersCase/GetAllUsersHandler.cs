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
        IBadcampContext _context;
        public GetAllUsersHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<IReadOnlyList<User>> Handle(GetAllUsersRequest message)
        {            
            try
            {
                IReadOnlyList<User> users = _context.Users.ToList();
                if (users == null)
                {
                    return Response.Fail<IReadOnlyList<User>>("Did not find any users!");
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
