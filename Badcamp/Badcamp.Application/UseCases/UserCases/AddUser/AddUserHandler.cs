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
        IBadcampContext _context;
        public AddUserHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<User> Handle(AddUserRequest message)
        {
            try
            {
                User user = message.NewUser;
                _context.Users.Add(user);
                _context.SaveChanges(); 
                return Response.Ok(user);
            }
            catch (Exception e)
            {
                return Response.Fail<User>(e.Message);

            }

        }
    }
}
