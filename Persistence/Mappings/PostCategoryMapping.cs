using JustBlog.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustBlog.Persistence.Mappings
{
    public class PostCategoryMapping : IEntityTypeConfiguration<PostCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<PostCategoryEntity> builder)
        {
            builder.HasKey(x => new {x.PostID , x.CategoryID});

            builder.HasOne(x => x.Category)
                .WithMany(y => y.PostCategories)
                .HasForeignKey(x => x.CategoryID);

            builder.HasOne(x => x.Post)
                .WithMany(y => y.PostCategories)
                .HasForeignKey(x => x.PostID);
        }
    }
}