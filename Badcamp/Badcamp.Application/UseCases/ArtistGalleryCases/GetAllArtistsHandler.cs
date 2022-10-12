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
    public class GetAllArtistsHandler : IRequestHandler<GetAllArtistsHandlerRequest, Response<IReadOnlyList<ArtistListItemDto>>>
    {

        private IBadcampContext _context;
        public GetAllArtistsHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<IReadOnlyList<ArtistListItemDto>> Handle(GetAllArtistsHandlerRequest message)
        {

            IReadOnlyList<ArtistListItemDto> artistsDtos;
            IList<Artist> artists;

            try
            {
                artists = _context.Artists.Include(artist => artist.Genres).ToList();
                artistsDtos = artists.Select(artist => new ArtistListItemDto
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Description = artist.Description,
                    ProfilePicture = artist.ProfilePicture,
                    Genres = artist.Genres.Select(g => g.Name).ToList()
                }).ToList();

                if(artists == null)
                {
                    return Response.Fail<IReadOnlyList<ArtistListItemDto>>("Artists not found");
                }
                return Response.Ok(artistsDtos);
            }
            catch(Exception e)
            {
                return Response.Fail<IReadOnlyList<ArtistListItemDto>>(e.Message);
            }
        }
    }
}
