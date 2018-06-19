using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogManagement.DAL.Entities;

namespace BlogManagement.DAL.Repository
{
    public class AccountRepository : IAccountRepository
    {

        private BlogDBContext context;

        public AccountRepository(BlogDBContext context)
        {
            this.context = context;
        }

        public void Add(Account acc)
        {
            context.Accounts.Add(acc);
        }

        public void Delete(Account acc)
        {
            context.Accounts.Remove(acc);
        }

        public Account getById(int id)
        {
            try
            {
                return context.Accounts.First(a => a.AccountId == id);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Account> getAll()
        {
            return context.Accounts;
        }

        public void Update(Account acc)
        {
            context.Accounts.Attach(acc);
            context.Entry(acc).State = System.Data.Entity.EntityState.Modified;
        }

        public Account getByEmail(string email)
        {
            try
            {
                return context.Accounts.First(a => a.Email.Equals(email));
            }
            catch
            {
                return null;
            }
        }
    }
}