using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badcamp.Application.Common;
using Badcamp.Domain.Entities;

namespace Badcamp.Application.UseCases.UserCases.AddUser
{
    public class AddUserRequest : IRequest<Response>
    {
        public User NewUser { get; set; } = new User();

    }
}
