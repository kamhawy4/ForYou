using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForYou.Application.Contracts;
using ForYou.Domain.Contracts;
using MediatR;

namespace ForYou.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommend>
    {

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCategoryCommend request, CancellationToken cancellationToken)
        {
          var gategory = await _unitOfWork.categories.GetByIdAsync(request.Id);

           await _unitOfWork.categories.DeleteAsync(gategory);
        }
    }
}
