using MicroServicio1.Database;
using MicroServicio1.Database.Entities;
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

        public void Dispose()
        {
            throw new NotImplementedException();
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
    }   
}
