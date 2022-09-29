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
        IBadcampContext _context;
        public DeleteUserByNameHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<User> Handle(DeleteUserByNameRequest message)
        {            
            try
            {
                User user = _context.Users.Where(u => u.Username == message.UserName).FirstOrDefault();
                if (user == null)
                {
                    return Response.Fail<User>("User does not exist!");
                }
                _context.Users.Remove(user);
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
