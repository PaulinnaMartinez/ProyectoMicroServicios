using MicroServicio2.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServicio2.DAL
{
    interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int id);
        void InsertUser(User user);
        void DeleteUser(int id);
        void UpdateUser(User user);
        void Save();
    }
}
