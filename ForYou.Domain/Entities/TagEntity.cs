using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Domain.Entities
{
    public class TagEntity
    {
        [Key]
        public Guid TagId { get; set; } = Guid.NewGuid();
        public string Title { get; set; }

        public IList<PostTagEntity> PostTag { get; set; }

    }
}