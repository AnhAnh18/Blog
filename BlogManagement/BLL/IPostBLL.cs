using BlogManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.BLL
{
    interface IPostBLL
    {
        Post get(int id);
        IEnumerable<Post> getAll();
        void Add(Post post);
        void Update(Post post);
        void Delete(Post post);
    }

}
