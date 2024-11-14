using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Domain.Entities
{
    public class PostTagEntity
    {
        public Guid PostId { get; set; }

        public PostEntity Post { get; set; }

        public Guid TagId { get; set; }

        public TagEntity Tag { get; set; }
    }
}
