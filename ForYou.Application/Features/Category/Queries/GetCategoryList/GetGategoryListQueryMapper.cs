using ForYou.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Category.Queries.GetCategoryList
{
    public static class GetGategoryListQueryMapper
    {
        public static List<GetCategoryListQueryViewModel> MapToGategoryDto(this IEnumerable<CategoryEntity> _) => _.Select(x => new GetCategoryListQueryViewModel()
        {
            Id = x.CategoryId,
            Name = x.Name,
        }).ToList();
    }
}
