using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogManagement.DAL.Entities;
using BlogManagement.DAL.UnitOfWork;

namespace BlogManagement.BLL
{
    public class AccountBLL : IAccountBLL
    {
        private IUnitOfWork uow;

        public AccountBLL(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Add(Account acc)
        {
            uow.accountRepository.Add(acc);
            uow.Save();
        }

        public void Delete(Account acc)
        {
            uow.accountRepository.Delete(acc);
            uow.Save();
        }

        public Account getById(int id)
        {
            try
            {
                return uow.accountRepository.getById(id);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Account> getAll()
        {
            return uow.accountRepository.getAll();
        }

        public void Update(Account acc)
        {
            uow.accountRepository.Update(acc);
            uow.Save();
        }

        public Account getByEmail(string email)
        {
            try
            {
                return uow.accountRepository.getByEmail(email);
            }
            catch
            {
                return null;
            }
        }
        
    }
}