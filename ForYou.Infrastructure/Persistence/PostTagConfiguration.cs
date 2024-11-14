using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Infrastructure.Persistence
{
    public class PostTagConfiguration : IEntityTypeConfiguration<PostTagConfiguration>
    {
        public void Configure(EntityTypeBuilder<PostTagConfiguration> builder)
        {

        }
    }
}
