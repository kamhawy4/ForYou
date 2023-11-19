using ForYou.Application.Features.Category.Queries.GetCategoryList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Category.Queries.GetCategoryList
{
    public class GetCategoryListQuery :IRequest<List<GetCategoryListQueryViewModel>>
    {

    }
}
