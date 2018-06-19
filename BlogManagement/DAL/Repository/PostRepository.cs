using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BlogManagement.DAL.Entities;

namespace BlogManagement.DAL.Repository
{
    public class PostRepository : IPostRepository
    {

        private BlogDBContext context;

        public PostRepository(BlogDBContext context)
        {
            this.context = context;
        }

        public void Add(Post post)
        {
            context.Posts.Add(post);
        }

        public void Delete(Post post)
        {
            context.Posts.Remove(post);
        }

        public Post get(int id)
        {
            return context.Posts.SingleOrDefault(a => a.PostId == id);
        }

        public IEnumerable<Post> getAll()
        {
            return context.Posts;
        }

        public void Update(Post post)
        {
            context.Posts.Attach(post);
            context.Entry(post).State = EntityState.Modified;
        }
    }
}