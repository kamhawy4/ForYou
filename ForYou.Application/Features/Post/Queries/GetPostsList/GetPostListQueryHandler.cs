using AutoMapper;
using ForYou.Application.Features.Post.Queries.GetPostsList;
using ForYou.Application.Interfaces;
using ForYou.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ForYou.SharedServices.Models;

namespace ForYou.Application.Features.Post.Queries.GetPostDetail
{
    public class GetPostListQueryHandler : IRequestHandler<GetPostListQuery, PaginatedResponseList<GetPostListQueryViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetPostListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResponseList<GetPostListQueryViewModel>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _unitOfWork.posts.Entities.Include(_=>_.Category)
                                                                .Include(o=>o.User)
                                                                    .Skip((request.PageNumber - 1) * request.PageSize)
                                                                        .Take(request.PageSize)
                                                                          .ToListAsync(cancellationToken);

            var totalCount = (await _unitOfWork.posts.Entities.CountAsync());

            var paginatedItemsDto = _mapper.Map<List<GetPostListQueryViewModel>>(allPosts);

            var result = new PaginatedResponseList<GetPostListQueryViewModel>
            {
                PageNumber  = request.PageNumber,
                PageSize = request.PageSize,
                TotalItems = totalCount,
                Data = paginatedItemsDto
            };
             return result;

        }
    }
}
