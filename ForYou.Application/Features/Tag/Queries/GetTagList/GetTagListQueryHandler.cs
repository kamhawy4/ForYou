using AutoMapper;
using ForYou.Application.Features.Category.Queries.GetCategoryList;
using ForYou.Application.Features.Tag.Queries.GetTagList;
using ForYou.Domain.Contracts;
using ForYou.SharedServices.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Tag.Queries.GetTagList
{
    public class GetTagListQueryHandler : IRequestHandler<GetTagListQuery, TResponse<List<GetTagListQueryViewModel>>>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public GetTagListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<TResponse<List<GetTagListQueryViewModel>>> Handle(GetTagListQuery request, CancellationToken cancellationToken)
        {

            var alltag = await _unitOfWork.tags.GetAllAsync();

            return TResponse<List<GetTagListQueryViewModel>>
                .Success(new List<GetTagListQueryViewModel>(
                  alltag.MapToTagDto()
                ));


        }
    }
}
