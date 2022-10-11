using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using Badcamp.Services;

namespace Badcamp.Application.UseCases.SongCases
{
    public class UpdateSongHandler: IRequestHandler<UpdateSongRequest, Response>
    {
        private IBadcampContext _context;

        public UpdateSongHandler(IBadcampContext context)
        {
            _context = context;
        }

        public Response Handle(UpdateSongRequest message)
        {
            try
            {
                _context.Songs.Update(message.updateData);
                _context.SaveChanges();
                return Response.Ok("Song Updated");
            }
            catch (Exception e)
            {
                return Response.Fail<Song>(e.Message);
            }
        }
    }
}
