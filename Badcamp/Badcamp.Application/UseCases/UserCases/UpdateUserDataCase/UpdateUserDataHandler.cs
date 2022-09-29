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
        IBadcampContext _context;
        public UpdateUserDataHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<User> Handle(UpdateUserDataRequest message)
        {
            try
            {
                var userToUpdate = _context.Users.Where(u => u.Username == message.UserName).FirstOrDefault();
                if (userToUpdate == null)
                {
                    return Response.Fail<User>("User does not exist!");
                }
                userToUpdate.Username = message.UpdatedUser.Username;
                userToUpdate.Password = message.UpdatedUser.Password;
                userToUpdate.FullName = message.UpdatedUser.FullName;
                _context.SaveChanges();
                return Response.Ok(userToUpdate);
            }
            catch (Exception e)
            {
                return Response.Fail<User>(e.Message);

            }

        }
  
    }
}
