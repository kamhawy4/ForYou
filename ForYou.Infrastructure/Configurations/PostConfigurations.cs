using ForYou.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Infrastructure.Configurations
{
    public class PostConfigurations : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(c => c.PostId);

            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Content).IsRequired();
        }
    }
}
