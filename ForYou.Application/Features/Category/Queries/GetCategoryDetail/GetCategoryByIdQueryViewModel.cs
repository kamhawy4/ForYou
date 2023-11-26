using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Category.Queries.GetCategoryDetail
{
    public class GetCategoryByIdQueryViewModel
    {
        public Guid id { get; set; }
        public string? name { get; set; }
        public DateTime? publishedDate { get; set; }
    }
}
