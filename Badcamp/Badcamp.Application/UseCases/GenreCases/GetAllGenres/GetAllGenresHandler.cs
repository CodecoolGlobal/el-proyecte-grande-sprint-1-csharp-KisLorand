using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.GenreCases.GetAllGenres
{
    public class GetAllGenresHandler : IRequestHandler<GetAllGenresRequest, Response<IReadOnlyList<Genre>>>
    {

        private IBadcampContext _context;
        public GetAllGenresHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<IReadOnlyList<Genre>> Handle(GetAllGenresRequest message)
        {
            try
            {
                var genres = _context.Genres.ToList();
                if (!genres.Any())
                {
                    return Response.Fail<IReadOnlyList<Genre>>("Genres not found");
                }
                return Response.Ok(genres as IReadOnlyList<Genre>); 
            }
            catch (Exception e)
            {

                return Response.Fail<IReadOnlyList<Genre>>(e.Message);
            }
        }
    }
}
