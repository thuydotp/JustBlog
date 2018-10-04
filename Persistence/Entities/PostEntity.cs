using System;
using System.Collections.Generic;

namespace JustBlog.Persistence.Entities
{
    public class PostEntity
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string MainContent { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public byte[] ThumbnailImage { get; set; }


        public AccountEntity Author { get; set; }
        public Guid AuthorID { get; set; }

        public List<PostCategoryEntity> PostCategories { get; set; }
    }

}