using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogManagement.DAL.Entities;
using BlogManagement.DAL.UnitOfWork;

namespace BlogManagement.BLL
{
    public class CommentBLL : ICommentBLL
    {
        private IUnitOfWork uow;

        public CommentBLL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Add(Comment cmt)
        {
            uow.commentRepository.Add(cmt);
            uow.Save();
        }

        public void Delete(Comment cmt)
        {
            uow.commentRepository.Delete(cmt);
            uow.Save();
        }

        public Comment get(int id)
        {
            return uow.commentRepository.get(id);
        }

        public IEnumerable<Comment> getAll()
        {
            return uow.commentRepository.getAll();
        }

        public void Update(Comment cmt)
        {
            uow.commentRepository.Update(cmt);
            uow.Save();
        }
    }
}