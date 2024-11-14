using AutoMapper;
using ForYou.Domain.Contracts;
using MediatR;

namespace ForYou.Application.Features.Tag.Queries.GetTagDetail
{
    public class GetTagListQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryViewModel>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetTagListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetTagByIdQueryViewModel> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await _unitOfWork.tags.GetByIdAsync(request.Id);

            return _mapper.Map<GetTagByIdQueryViewModel>(tag);

        }
    }
}
