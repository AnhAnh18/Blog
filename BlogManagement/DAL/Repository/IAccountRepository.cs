using BlogManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogManagement.DAL.Repository
{
    public interface IAccountRepository
    {
        Account getById(int id);
        Account getByEmail(String email);
        IEnumerable<Account> getAll();
        void Add(Account acc);
        void Update(Account acc);
        void Delete(Account acc);
    }
}