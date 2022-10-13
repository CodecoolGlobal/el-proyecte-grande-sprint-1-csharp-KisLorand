using Badcamp.Domain.Entities;
using Badcamp.Models;
using Microsoft.EntityFrameworkCore;

namespace Badcamp.Application
{
    public interface IBadcampContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Artist> Artists { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<Song> Songs { get; set; }
        DbSet<Playlist> Playlists { get; set; }
        void SaveChanges();
        
    }
}