using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Domain.Entities
{
    public class ArtistListItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public List<string> Genres { get; set; }
    }
}
