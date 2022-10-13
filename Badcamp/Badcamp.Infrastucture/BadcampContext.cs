using Badcamp.Application;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using Microsoft.EntityFrameworkCore;

namespace Badcamp.Infrastucture
{
    public class BadcampContext : DbContext, IBadcampContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public BadcampContext(DbContextOptions<BadcampContext> options)
        : base(options)
        {

        }

        void IBadcampContext.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}