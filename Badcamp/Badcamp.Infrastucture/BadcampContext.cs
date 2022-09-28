using Badcamp.Application;
using Badcamp.Models;
using Microsoft.EntityFrameworkCore;

namespace Badcamp.Infrastucture
{
    public class BadcampContext : DbContext, IBadcampContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ArtistModel> ArtistModels { get; set; }
        public BadcampContext(DbContextOptions<BadcampContext> options)
        :base(options)
        {
           
        }

    
    }
}