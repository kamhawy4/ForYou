using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Comment.Queries.GetCommentsDetail
{
    public class GetCommentByIdQueryViewModel
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }

        public DateTime? publishedDate { get; set; }

    }
}
