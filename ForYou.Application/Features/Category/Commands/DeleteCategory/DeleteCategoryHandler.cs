using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForYou.Application.Contracts;
using ForYou.Domain.Contracts;
using ForYou.SharedServices.Interfaces;
using ForYou.SharedServices.Services;
using MediatR;

namespace ForYou.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommend>
    {

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public DeleteCategoryHandler(IMapper mapper, IUnitOfWork unitOfWork, IEmailService emailServic)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _emailService = emailServic;
        }

        public async Task Handle(DeleteCategoryCommend request, CancellationToken cancellationToken)
        {
          var gategory = await _unitOfWork.categories.GetByIdAsync(request.Id);

           await _unitOfWork.categories.DeleteAsync(gategory);


        }
    }
}
