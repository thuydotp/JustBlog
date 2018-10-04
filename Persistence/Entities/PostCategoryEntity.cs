using System;

namespace JustBlog.Persistence.Entities
{
    
    public class PostCategoryEntity
    {
        public Guid PostID { get; set; }
        public PostEntity Post { get; set; }
        public Guid CategoryID { get; set; }
        public CategoryEntity Category { get; set; }
    }
}