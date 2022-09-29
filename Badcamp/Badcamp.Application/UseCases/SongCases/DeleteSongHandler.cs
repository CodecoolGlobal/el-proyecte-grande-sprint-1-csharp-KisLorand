using Badcamp.Application.Common;
using Badcamp.Models;
using Badcamp.Services;

namespace Badcamp.Application.UseCases.SongCases
{
    public class DeleteSongHandler
    {
        private IBadcampContext _context;
        public DeleteSongHandler(IBadcampContext context)
        {
            _context = context;
        }

        public void Handle(DeleteSongRequest message)
        {
            _context.Songs.Remove(message.song);
            _context.SaveChanges();
        }
    }
}
