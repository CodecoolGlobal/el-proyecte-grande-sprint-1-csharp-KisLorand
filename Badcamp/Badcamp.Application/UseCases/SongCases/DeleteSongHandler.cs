using Badcamp.Application.Common;
using Badcamp.Models;
using Badcamp.Services;

namespace Badcamp.Application.UseCases.SongCases
{
    public class DeleteSongHandler: IRequestHandler<DeleteSongRequest, Response>
    {
        private IBadcampContext _context;
        public DeleteSongHandler(IBadcampContext context)
        {
            _context = context;
        }

        public Response Handle(DeleteSongRequest message)
        {
            try
            {
                _context.Songs.Remove(message.song);
                _context.SaveChanges();
                return Response.Ok("Song Deleted");
            }
            catch (Exception e)
            {
                return Response.Fail(e.Message);
            }
        }
    }
}
