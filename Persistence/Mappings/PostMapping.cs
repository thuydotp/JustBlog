using JustBlog.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustBlog.Persistence.Mappings
{
    public class PostMapping : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .HasMaxLength(250)
                .IsUnicode()
                .IsRequired();

            builder.Property(x => x.ShortDescription)
                .HasColumnType("ntext");

            builder.Property(x => x.MainContent)
                .HasColumnType("ntext")
                .IsRequired();

            builder.Property(x => x.Slug)
                .HasMaxLength(250);

            builder.Property(x => x.CreatedDate)
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");

            builder.Property(x => x.UpdatedDate)
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");

            builder.HasOne(x => x.Author)
                .WithMany()
                .HasForeignKey(x => x.AuthorID);
        }
    }
}