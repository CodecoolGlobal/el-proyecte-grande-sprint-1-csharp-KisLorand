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
            throw new NotImplementedException();
        }
    }
}
