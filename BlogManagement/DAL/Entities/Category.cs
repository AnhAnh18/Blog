using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogManagement.DAL.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public String Name { get; set; }

        public Category()
        {
        }

        public Category(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }

        public IEnumerable<Post> Posts { get; set; }
    }
}