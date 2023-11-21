using AutoMapper;
using ForYou.Application.Contracts;
using ForYou.Application.Features.Category.Queries.GetCategoryDetail;
using ForYou.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Category.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<GetCategoryListQueryViewModel>>
    {
        private readonly IMapper _mapper;

        private readonly IGategoryRepository _gategoryRepository;

        public GetCategoryListQueryHandler(IGategoryRepository gategoryRepository, IMapper mapper)
        {
            _gategoryRepository = gategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryListQueryViewModel>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var allGategory = await _gategoryRepository.GetAllAsync();

            return _mapper.Map<List<GetCategoryListQueryViewModel>>(allGategory);
        }
    }
}
