using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForYou.Application.Contracts;
using MediatR;

namespace ForYou.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommend>
    {

        private readonly IGategoryRepository _gategoryRepository;

        public DeleteCategoryHandler(IGategoryRepository gategoryRepository)
        {
            _gategoryRepository = gategoryRepository;
        }

        public async Task Handle(DeleteCategoryCommend request, CancellationToken cancellationToken)
        {
          var gategory = await _gategoryRepository.GetByIdAsync(request.Id);

           await _gategoryRepository.DeleteAsync(gategory);
        }
    }
}
