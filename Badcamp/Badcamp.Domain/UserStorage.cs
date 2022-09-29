using Badcamp.Domain.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Badcamp.Models
{
    public class UserStorage
    {
        private List<User> _users;

        public UserStorage()
        {
            _users = new List<User>();
            _users.Add(new User("testName", "testPassword", new DateTime(1999,12,11), "Damn Son"));
        }

        public void AddUser(User user)
        {
            user.Id = _users.Count;
            _users.Add(user);
        }

        public IReadOnlyList<User> GetAllUsers()
        {
            return _users.AsReadOnly();
        }

        public User GetUserByName(string userName)
        {
            foreach (var user in _users)
            {
                if (user.Username == userName)
                    return user;
            }

            throw new Exception("Given user does not exist!");
        }

        public void UpdateUserData(string currentUser ,User updatedUser)
        {
            foreach (var user in _users)
            {
                if (user.Username != currentUser) continue;
                user.Username = updatedUser.Username;
                user.FullName = updatedUser.FullName;
                user.Password = updatedUser.Password;
                user.DateOfBirth = updatedUser.DateOfBirth;
            }
        }

        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }

    }
}
