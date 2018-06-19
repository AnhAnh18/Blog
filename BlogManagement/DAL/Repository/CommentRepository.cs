using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogManagement.DAL.Entities;

namespace BlogManagement.DAL.Repository
{
    public class CommentRepository : ICommentRepository
    {

        private BlogDBContext context;

        public CommentRepository(BlogDBContext context)
        {
            this.context = context;
        }

        public void Add(Comment cmt)
        {
            context.Comments.Add(cmt);
        }

        public void Delete(Comment cmt)
        {
            context.Comments.Remove(cmt);
        }

        public Comment get(int id)
        {
            return context.Comments.SingleOrDefault(a => a.CommentId == id);
        }

        public IEnumerable<Comment> getAll()
        {
            return context.Comments;
        }

        public void Update(Comment cmt)
        {
            context.Comments.Attach(cmt);
            context.Entry(cmt).State = System.Data.Entity.EntityState.Modified;
        }
    }
}