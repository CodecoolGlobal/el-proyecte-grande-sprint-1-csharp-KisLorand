using Badcamp.Models;
using Microsoft.EntityFrameworkCore;

namespace Badcamp.Application
{
    public interface IBadcampContext
    {
        DbSet<User> Users { get; set; }
        DbSet<ArtistModel> ArtistModels { get; set; }
    }
}