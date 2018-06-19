using BlogManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.BLL
{
    interface ICategoryBLL
    {
        Category get(int id);
        IEnumerable<Category> getAll();
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
