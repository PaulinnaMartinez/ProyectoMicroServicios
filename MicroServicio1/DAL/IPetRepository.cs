using MicroServicio1.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServicio1.DAL
{
    public interface IPetRepository: IDisposable
    {
        IEnumerable<Pet> GetPets();
        Pet GetPetByID(int id);
        void InsertPet(Pet pet);
        void DeletePet(int PetId);
        void UpdatePet(Pet pet);
    }
}
