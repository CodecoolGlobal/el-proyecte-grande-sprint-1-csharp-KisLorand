namespace Badcamp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FullName { get; set; }
        public int? ArtistId { get; set; }

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
