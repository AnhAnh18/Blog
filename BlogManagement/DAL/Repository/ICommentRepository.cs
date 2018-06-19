using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogManagement.DAL.Entities;

namespace BlogManagement.DAL.Repository
{
    public interface ICommentRepository
    {
        Comment get(int id);
        IEnumerable<Comment> getAll();
        void Add(Comment cmt);
        void Update(Comment cmt);
        void Delete(Comment cmt);
    }
}
