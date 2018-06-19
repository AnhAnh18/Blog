using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogManagement.DAL.Entities;
using BlogManagement.DAL.UnitOfWork;

namespace BlogManagement.BLL
{
    public class CategoryBLL : ICategoryBLL
    {
        private IUnitOfWork uow;

        public CategoryBLL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Add(Category category)
        {
            uow.categoryRepository.Add(category);
            uow.Save();
        }

        public void Delete(Category category)
        {
            uow.categoryRepository.Delete(category);
            uow.Save();
        }

        public Category get(int id)
        {
            return uow.categoryRepository.get(id);
        }

        public IEnumerable<Category> getAll()
        {
            return uow.categoryRepository.getAll();
        }

        public void Update(Category category)
        {
            uow.categoryRepository.Update(category);
            uow.Save();
        }
    }
}