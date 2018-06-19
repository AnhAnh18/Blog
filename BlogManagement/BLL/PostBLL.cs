using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogManagement.DAL.Entities;
using BlogManagement.DAL.UnitOfWork;

namespace BlogManagement.BLL
{
    public class PostBLL : IPostBLL
    {
        private IUnitOfWork uow;

        public PostBLL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Add(Post post)
        {
            uow.postRepository.Add(post);
        }

        public void Delete(Post post)
        {
            uow.postRepository.Delete(post);
        }

        public Post get(int id)
        {
            return uow.postRepository.get(id);
        }

        public IEnumerable<Post> getAll()
        {
            return uow.postRepository.getAll();
        }

        public void Update(Post post)
        {
            uow.postRepository.Update(post);
        }
        public IEnumerable<Post> getPostsByAccountId(int id)
        {
            return uow.postRepository.getAll().Where(x => x.AccountId == id);
        }
    }
}