using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using Badcamp.Services;

namespace Badcamp.Application.UseCases.SongCases
{
    public class GetAllSongsHandler : IRequestHandler<GetAllSongsRequest, Response<IReadOnlyList<Song>>>
    {
        private IBadcampContext _context;

        public GetAllSongsHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<IReadOnlyList<Song>> Handle(GetAllSongsRequest message)
        {
            try
            {
                IReadOnlyList<Song> songs = _context.Songs.ToList();
                if (songs == null)
                {
                    return Response.Fail<IReadOnlyList<Song>>("No songs were found");
                }
                return Response.Ok(songs);
            }
            catch (Exception e)
            {
                return Response.Fail<IReadOnlyList<Song>>(e.Message);

            }

        }
    }
}