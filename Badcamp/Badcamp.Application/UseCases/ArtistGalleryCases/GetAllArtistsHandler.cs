using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistGalleryCases
{
    public class GetAllArtistsHandler : IRequestHandler<GetAllArtistsHandlerRequest, Response<IReadOnlyList<Artist>>>
    {

        private ArtistStorage _storage;
        public GetAllArtistsHandler(ArtistStorage storage)
        {
            _storage = storage;
        }
        public Response<IReadOnlyList<Artist>> Handle(GetAllArtistsHandlerRequest message)
        {

            IReadOnlyList<Artist> artists;

            try
            {
                artists = (IReadOnlyList<Artist>)_storage.GetArtists();
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
