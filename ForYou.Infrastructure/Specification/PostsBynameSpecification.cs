using ForYou.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Infrastructure.Specification
{
    public class PostsBynameSpecification : Specifcation<PostEntity>
    {
        public PostsBynameSpecification(Guid id) : base(x=>x.PostId == id)
        {
            AddOrderByDescending(x => x.PublishedDate);
        }
    }
}
