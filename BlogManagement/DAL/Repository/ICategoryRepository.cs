using BlogManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogManagement.DAL.Repository
{
    public interface ICategoryRepository
    {
        Category get(int id);
        IEnumerable<Category> getAll();
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}