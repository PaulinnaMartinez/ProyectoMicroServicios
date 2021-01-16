using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC.Helper
{
    public class PetAPI
    {
        public HttpClient initial()
        {
            var pet = new HttpClient();
            pet.BaseAddress = new Uri("http://localhost:51028");
            return pet;
        }
    }
}
