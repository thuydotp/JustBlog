using JustBlog.Persistence.Entities;
using JustBlog.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace JustBlog.Persistence
{
    public class JustBlogContext : DbContext
    {
        public JustBlogContext(DbContextOptions<JustBlogContext> options)
            : base(options)
        { }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new PostCategoryMapping());
            modelBuilder.ApplyConfiguration(new PostMapping());
        }

        public DbSet<JustBlog.Persistence.Entities.PostCategoryEntity> PostCategoryEntity { get; set; }
    }
}