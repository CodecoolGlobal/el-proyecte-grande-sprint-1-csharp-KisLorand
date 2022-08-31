using Badcamp.Models;

namespace Badcamp.Services
{
    public class UserStorage
    {
        private List<User> _users;

        public UserStorage()
        {
            _users = new List<User>();
        }

    }
}
