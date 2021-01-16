using MicroServicio1.DAL;
using MicroServicio1.Database;
using MicroServicio1.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroServicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetRepository _petRepository;
        //DatabaseContext db;

        /*public PetController(IPetRepository petRepository)
        {
            this._petRepository = petRepository;
        }*/

        public PetController()
        {
            this._petRepository = new PetRepository(new DatabaseContext());
            //db = new DatabaseContext();
        }



        // GET: api/<PetController>
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return _petRepository.GetPets();
            //return db.Pets.ToList();
        }

        // GET api/<PetController>/5
        [HttpGet("{id}")]
        public Pet Get(int id)
        {
            return _petRepository.GetPetByID(id);
            //return db.Pets.Find(id);
        }

        // POST api/<PetController>
        [HttpPost]
        public void Post([FromBody] Pet model)
        {
            try
            {
                _petRepository.InsertPet(model);
                //db.Pets.Add(model);
                //db.SaveChanges();
            }
            catch { 
            }
        }

        // PUT api/<PetController>/5
        [HttpPut ("{id}")]
        public void Put(Pet model)
        {
            _petRepository.UpdatePet(model);
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _petRepository.DeletePet(id);
            }
            catch
            {

            }
        }
    }
}
