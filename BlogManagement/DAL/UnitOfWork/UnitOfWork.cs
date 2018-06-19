using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogManagement.DAL.Repository;
using BlogManagement.DAL.Entities;

namespace BlogManagement.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private BlogDBContext context;

        public UnitOfWork(BlogDBContext context)
        {
            this.context = context;
            initRepos();
        }

        private void initRepos()
        {
            accountRepository = new AccountRepository(context);
            categoryRepository = new CategoryRepository(context);
            commentRepository = new CommentRepository(context);
            postRepository = new PostRepository(context);
        }

        public IAccountRepository accountRepository { get; private set; }

        public ICategoryRepository categoryRepository { get; private set; }

        public ICommentRepository commentRepository { get; private set; }

        public IPostRepository postRepository { get; private set; }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}