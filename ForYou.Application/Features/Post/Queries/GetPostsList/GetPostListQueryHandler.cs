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
            try
            {
                var allPosts = await _unitOfWork.posts.Entities.Skip((request.PageNumber - 1) * request.PageSize)
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
            catch (Exception ex)
            {
                // Log the exception (use your logging framework)
                Console.WriteLine(ex.Message);

                // Re-throw the exception or return a meaningful error response
                throw new Exception("An error occurred while processing your request.", ex);
            }

        }
    }
}
