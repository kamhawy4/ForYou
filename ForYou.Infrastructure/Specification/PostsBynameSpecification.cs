using ForYou.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Infrastructure.Specification
{
    public class PostsBynameSpecification : BaseSpecifcation<PostEntity>
    {
        public PostsBynameSpecification()
        {
            AddOrderByDescending(x => x.Title);
        }
    }
}
