using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badcamp.Application.Common;

namespace Badcamp.Application.UseCases.UserCases.AddUser
{
    public class AddUserRequest : IRequest<Response>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string FullName { get; set; } = string.Empty;

    }
}
