using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Domain.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public HashSet<Song>? Songs { get; set; }
    }
}
