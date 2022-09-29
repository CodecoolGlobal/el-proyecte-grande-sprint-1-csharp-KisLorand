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
    public class UpdateUserDataRequest : IRequest<Response>
    {
        public string UserName { get; set; } = string.Empty;
        public User UpdatedUser { get; set; } = new User();
    }
}
