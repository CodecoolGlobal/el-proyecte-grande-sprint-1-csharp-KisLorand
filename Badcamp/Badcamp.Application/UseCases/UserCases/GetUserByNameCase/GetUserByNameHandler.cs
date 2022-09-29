using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases
{
    public class GetUserByNameHandler : IRequestHandler<GetUserByNameRequest, Response<User>>
    {
        IBadcampContext _context;
        
        public GetUserByNameHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<User> Handle(GetUserByNameRequest message)
        {
            try
            {
                var user = _context.Users
                    .Where(x => x.Username == message.UserName)
                    .FirstOrDefault();

                if(user == null)
                {
                    return Response.Fail<User>("User not found");
                }
                return Response.Ok<User>(user);
            }
            catch (Exception e)
            {
                return Response.Fail<User>(e.Message);
            }
         
        }
    }
}
