using MicroServicio1.Database;
using MicroServicio1.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServicio1.DAL
{
    public class PetRepository : IPetRepository, IDisposable
    {
        private DatabaseContext db;
        public PetRepository(DatabaseContext context)
        {
            this.db = context;
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Pet GetPetByID(int id)
        {
            return db.Pets.Find(id);
        }

        public IEnumerable<Pet> GetPets()
        {
            return db.Pets.ToList();
        }

        public void InsertPet(Pet pet)
        {
            db.Pets.Add(pet);
            db.SaveChanges();
        }

        public void DeletePet(int PetId)
        {
            Pet pet = db.Pets.Find(PetId);
            db.Pets.Remove(pet);
            db.SaveChanges();
        }

        public void UpdatePet(Pet pet)
        {
            db.Pets.Update(pet);
            db.SaveChanges();
        }
    }   
}
