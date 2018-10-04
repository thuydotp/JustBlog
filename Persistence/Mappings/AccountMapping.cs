using JustBlog.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustBlog.Persistence.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UserName)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(250)
                .IsUnicode()
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(250)
                .IsUnicode()
                .IsRequired();
        }
    }
}