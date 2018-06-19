namespace BlogManagement.DAL.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BlogDBContext : DbContext
    {
        public BlogDBContext()
            : base("name=BlogDBContext")
        {
        }

        public virtual DbSet<Account> Accounts{ get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
    
}