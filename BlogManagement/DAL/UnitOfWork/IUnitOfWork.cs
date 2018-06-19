using BlogManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAccountRepository accountRepository { get; }
        ICategoryRepository categoryRepository { get; }
        ICommentRepository commentRepository { get; }
        IPostRepository postRepository { get; }
        void Save();
    }
}
