using Badcamp.Models;

namespace Badcamp.Services
{
    public class UserStorage
    {
        private List<User> _users;

        public UserStorage()
        {
            _users = new List<User>();
            _users.Add(new User(1, "testName", "testPassword"));
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public IReadOnlyList<User> GetUsers()
        {
            return _users.AsReadOnly();
        }

        public void UpdateUserPassword(string userName, string newPassword)
        {
            foreach (var user in _users)
            {
                if (user.Username == userName)
                {
                    user.Password = newPassword;
                }
            }
        }

        

    }
}
