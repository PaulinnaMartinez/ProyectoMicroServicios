using MicroServicio1.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServicio1.Database
{
    public class DatabaseContext: DbContext
    {
      
        public DbSet<Pet> Pets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-QMQQUMM3\\SQLEXPRESS;Database=MicroService1;Trusted_Connection=True;");
        }



    }
}

