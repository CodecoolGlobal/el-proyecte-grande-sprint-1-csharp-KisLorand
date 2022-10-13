using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using Badcamp.Services;

namespace Badcamp.Application.UseCases.SongCases
{
    public class GetSongHandler : IRequestHandler<GetSongRequest, Response<Song>>
    {
        private IBadcampContext _context;

        public GetSongHandler(IBadcampContext context)
        {
            _context = context;
        }

        public Response<Song> Handle(GetSongRequest message)
        {
            try
            {
                var song = _context.Songs.FirstOrDefault(s => s.Id == message.Id);
                if (song == null)
                {
                    return Response.Fail<Song>($"No Song with ID:{message.Id} was found.");
                }
                return Response.Ok(song);
            }
            catch (Exception e)
            {
                return Response.Fail<Song>(e.Message);
            }
        }
    }
}
