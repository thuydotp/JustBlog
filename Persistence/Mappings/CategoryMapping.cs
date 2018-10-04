using JustBlog.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustBlog.Persistence.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CategoryName)
                .HasMaxLength(250)
                .IsUnicode()
                .IsRequired();

            //TODO Many To Many
        }
    }
}