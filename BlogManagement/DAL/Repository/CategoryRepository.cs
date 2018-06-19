using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogManagement.DAL.Entities;

namespace BlogManagement.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private BlogDBContext context;

        public CategoryRepository(BlogDBContext context)
        {
            this.context = context;
        }

        public void Add(Category category)
        {
            context.Categories.Add(category);
        }

        public void Delete(Category category)
        {
            context.Categories.Remove(category);
        }

        public Category get(int id)
        {
            return context.Categories.SingleOrDefault(a => a.CategoryId == id);
        }

        public IEnumerable<Category> getAll()
        {
            return context.Categories;
        }

        public void Update(Category category)
        {
            context.Categories.Attach(category);
            context.Entry(category).State = System.Data.Entity.EntityState.Modified;
        }
    }
}