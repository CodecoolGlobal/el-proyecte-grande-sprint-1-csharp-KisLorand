using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace Badcamp.Application.UseCases.LoginCase
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, Response<User>>
    {
        IBadcampContext _context;
        IConfiguration _config;

        public LoginUserHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<User> Handle(LoginUserRequest message)
        {
            throw new NotImplementedException();
        }

        public Response Handle(LoginUserRequest message, IConfiguration config)
        {
            _config = config;

            try
            {
                var user = AuthenticateUser(message);

                if (user == null)
                {
                    return Response.Fail($"User {message.Username} not found");
                }

                var token = GenerateToken(user);

                return Response.Ok(token);
            }
            catch (Exception e)
            {
                return Response.Fail(e.Message);
            }

        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creditentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creditentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(LoginUserRequest userRequest)
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.Username.ToLower() ==
                userRequest.Username.ToLower() && u.Password == userRequest.Password);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
       
    }
}
