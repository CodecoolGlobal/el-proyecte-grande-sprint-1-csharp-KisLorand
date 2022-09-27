using Badcamp.Application.Common;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistGalleryCases
{
   
    public class GetAllArtistsHandler : IRequestHandler<GetAllArtistsHandlerRequest, Response<IReadOnlyList<ArtistModel>>>
    {

        private ArtistStorage _storage;
        public GetAllArtistsHandler(ArtistStorage storage)
        {
            _storage = storage;
        }
        public Response<IReadOnlyList<ArtistModel>> Handle(GetAllArtistsHandlerRequest message)
        {

            IReadOnlyList<ArtistModel> artists;

            try
            {
                artists = (IReadOnlyList<ArtistModel>)_storage.GetArtists();
                if(artists == null)
                {
                    return Response.Fail<IReadOnlyList<ArtistModel>>("Artists not found");
                }
                return Response.Ok(artists);
            }
            catch(Exception e)
            {
                return Response.Fail<IReadOnlyList<ArtistModel>>(e.Message);
            }
        }
    }
}
