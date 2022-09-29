using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.GenreCases.GetGenre
{
    public class GetGenreHandler : IRequestHandler<GetGenreRequest, Response<Genre>>
    {

        private IBadcampContext _context;
        public GetGenreHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<Genre> Handle(GetGenreRequest message)
        {
            long id = message.Id;
            Genre genre;
            try
            {
               genre = _context.Genres.Find(id);
               if (genre == null)
                {
                    return Response.Fail<Genre>("Genre not found");
                }
               return Response.Ok(genre);
            }
            catch (Exception e)
            {

               return Response.Fail<Genre>(e.Message);
            }
        }
    }
}
