using ForYou.Application.Features.Category.Queries.GetCategoryDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Category.Queries.GetPostDetail
{
    public class GetCategoryByIdQuery :IRequest<GetCategoryByIdQueryViewModel>
    {
        public Guid Id { get; set; }
    }
}
