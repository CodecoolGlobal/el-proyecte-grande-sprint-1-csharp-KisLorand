using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistGalleryCases
{
    public class GetAllArtistsHandler : IRequestHandler<GetAllArtistsHandlerRequest, Response<IReadOnlyList<Artist>>>
    {

        private IBadcampContext _context;
        public GetAllArtistsHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<IReadOnlyList<Artist>> Handle(GetAllArtistsHandlerRequest message)
        {

            IReadOnlyList<Artist> artists;

            try
            {
                artists = _context.Artists.Include(artist => artist.Genres).ToList();
                if(artists == null)
                {
                    return Response.Fail<IReadOnlyList<Artist>>("Artists not found");
                }
                return Response.Ok(artists);
            }
            catch(Exception e)
            {
                return Response.Fail<IReadOnlyList<Artist>>(e.Message);
            }
        }
    }
}
