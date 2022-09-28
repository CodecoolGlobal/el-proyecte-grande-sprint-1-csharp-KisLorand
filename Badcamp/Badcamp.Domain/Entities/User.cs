namespace Badcamp.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FullName { get; set; }
        public ArtistModel Artist { get; set; }

        public User()
        {
        }

        public User(string username, string password, DateTime dateOfBirth, string fullName)
        {
            Username = username;
            Password = password;
            DateOfBirth = dateOfBirth;
            FullName = fullName;
        }


    }
}
