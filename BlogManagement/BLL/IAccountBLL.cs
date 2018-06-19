using BlogManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.BLL
{
    public interface IAccountBLL
    {
        Account getById(int id);
        Account getByEmail(String email);
        IEnumerable<Account> getAll();
        void Add(Account acc);
        void Update(Account acc);
        void Delete(Account acc);
    }
}
