using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.GenreCases.DeleteGenre
{
    internal class DeleteGenreHandler : IRequestHandler<DeleteGenreRequest, Response<Genre>>
    {

        private IBadcampContext _context;
        public DeleteGenreHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<Genre> Handle(DeleteGenreRequest message)
        {
            try
            {
                var genre = _context.Genres.Find(message.Id);
                if (genre == null)
                {
                    return Response.Fail<Genre>("Genre not found");
                }
                _context.Genres.Remove(genre);
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
