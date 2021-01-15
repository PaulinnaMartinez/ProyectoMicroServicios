using MicroServicio2.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServicio2.Database
{
    public class DatabaseContext : DbContext
    {

        public DbSet <User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-QMQQUMM3\\SQLEXPRESS;Database=MicroService2;Trusted_Connection=True;");
        }



    }
}

