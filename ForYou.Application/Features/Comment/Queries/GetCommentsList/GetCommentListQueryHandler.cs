using AutoMapper;
using ForYou.Application.Contracts;
using ForYou.Application.Features.Category.Queries.GetCategoryList;
using ForYou.Application.Features.Post.Queries.GetPostDetail;
using ForYou.Application.Interfaces;
using ForYou.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Comment.Queries.GetCommentsList
{
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, List<GetCommentListQueryViewModel>>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public GetCommentListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetCommentListQueryViewModel>> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
            var comments = await _unitOfWork.comments.GetAllAsync();

            return _mapper.Map<List<GetCommentListQueryViewModel>>(comments);

        }
    }
}
