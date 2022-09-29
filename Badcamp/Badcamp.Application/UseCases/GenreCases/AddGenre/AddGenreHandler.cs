using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.GenreCases.AddGenre
{
    public class AddGenreHandler : IRequestHandler<AddGenreRequest, Response<Genre>>
    {

        private IBadcampContext _context;

        public AddGenreHandler(IBadcampContext context)
        {
            _context = context;

        }

        public Response<Genre> Handle(AddGenreRequest message)
        {
            var genre = new Genre() { Name = message.Name};
            try
            {
                _context.Genres.Add(genre);
                _context.SaveChanges();
                return Response.Ok(genre);
            }
            catch (Exception e)
            {

                return Response.Fail<Genre>(e.Message);
            }
        }
    }
}
