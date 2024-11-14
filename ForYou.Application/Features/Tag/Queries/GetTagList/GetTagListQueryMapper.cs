using ForYou.Application.Features.Tag.Queries.GetTagList;
using ForYou.Domain.Entities;

namespace ForYou.Application.Features.Category.Queries.GetCategoryList
{
    public static class GetTagListQueryMapper
    {
        public static List<GetTagListQueryViewModel> MapToTagDto(this IEnumerable<TagEntity> _) => _.Select(x => new GetTagListQueryViewModel()
        {
            TagId = x.TagId,
            Title = x.Title,
        }).ToList();
    }
}
