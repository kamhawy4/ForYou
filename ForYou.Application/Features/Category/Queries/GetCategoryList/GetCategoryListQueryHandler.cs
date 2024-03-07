using AutoMapper;
using ForYou.Application.Features.Authentication.Login;
using ForYou.Domain.Contracts;
using ForYou.SharedServices.Models;
using MediatR;

namespace ForYou.Application.Features.Category.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, TResponse<List<GetCategoryListQueryViewModel>>>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<TResponse<List<GetCategoryListQueryViewModel>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
           
            var allGategory = await _unitOfWork.categories.GetAllAsync();

            //return _mapper.Map<TResponse<List<GetCategoryListQueryViewModel>>>(allGategory);

            return TResponse<List<GetCategoryListQueryViewModel>>.Success(new List<GetCategoryListQueryViewModel>(
                  allGategory.MapToGategoryDto()
                ));
            

        }
    }
}
