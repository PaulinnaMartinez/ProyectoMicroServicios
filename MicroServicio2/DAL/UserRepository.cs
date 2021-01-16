using MicroServicio2.Database;
using MicroServicio2.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServicio2.DAL
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private DatabaseContext db;
        public UserRepository(DatabaseContext context)
        {
            this.db = context;
        }

        public void DeleteUser(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            Save();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<User> GetUsers()
        {
            return db.User.ToList();
        }

        public void InsertUser(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            Save();
        }

        public User GetUserByID(int id)
        {
            return db.User.Find(id);
        }
    }
}
