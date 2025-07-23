using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Entities;

namespace Shop.Domain.IRepository
{
    public interface IUserRepository
    {
        Task<User> IsUser(int userId);
        Task<User> GetByUserName(string userName);
    }
}
