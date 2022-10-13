using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.GenreCases.GetAllGenres
{
    public class GetAllGenresHandler : IRequestHandler<GetAllGenresRequest, Response<IReadOnlyList<string>>>
    {

        private IBadcampContext _context;
        public GetAllGenresHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<IReadOnlyList<string>> Handle(GetAllGenresRequest message)
        {
            try
            {
                var genres = _context.Genres.Select(x => x.Name).ToList();
                if (!genres.Any())
                {
                    return Response.Fail<IReadOnlyList<string>>("Genres not found");
                }
                return Response.Ok(genres as IReadOnlyList<string>); 
            }
            catch (Exception e)
            {

                return Response.Fail<IReadOnlyList<string>>(e.Message);
            }
        }
    }
}
