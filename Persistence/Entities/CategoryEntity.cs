using System;
using System.Collections.Generic;

namespace JustBlog.Persistence.Entities
{
    public class CategoryEntity
    {
        public Guid ID { get; set; }
        public string CategoryName { get; set; }
            
        public List<PostCategoryEntity> PostCategories { get; set; }
    }
}