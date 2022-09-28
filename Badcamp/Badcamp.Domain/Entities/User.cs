namespace Badcamp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; }
        public string FullName { get; set; } = String.Empty;
        public int? ArtistId { get; set; }

        public User()
        {
        }

        public User(string username, string password, DateTime dateOfBirth, string fullName)
        {
            Username = username;
            Password = password;
            DateOfBirth = dateOfBirth;
            FullName = fullName;
            ArtistId = null;
        }


    }
}
