using AutoMapper;
using ForYou.Application.Contracts;
using ForYou.Application.Interfaces;
using ForYou.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Category.Queries.GetCategoryDetail
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryViewModel>
    {

        private readonly IMapper _mapper;

        private readonly IGategoryRepository _gategoryRepository;

        public GetCategoryByIdQueryHandler(IGategoryRepository gategoryRepository, IMapper mapper)
        {
            _gategoryRepository = gategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdQueryViewModel> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var gategory =  await _gategoryRepository.GetByIdAsync(request.Id);

            return _mapper.Map<GetCategoryByIdQueryViewModel>(gategory);
        }
    }
}
