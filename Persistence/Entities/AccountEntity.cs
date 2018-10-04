using System;
using System.Collections.Generic;

namespace JustBlog.Persistence.Entities
{
    public class AccountEntity
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}