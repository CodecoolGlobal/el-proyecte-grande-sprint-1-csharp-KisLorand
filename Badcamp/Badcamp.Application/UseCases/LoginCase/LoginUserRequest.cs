using Badcamp.Application.Common;

namespace Badcamp.Application.UseCases.LoginCase
{
    public class LoginUserRequest : IRequest<Response>
    {
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
