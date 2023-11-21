using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Category.Queries.GetCategoryList
{
    public class GetCategoryListQueryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
