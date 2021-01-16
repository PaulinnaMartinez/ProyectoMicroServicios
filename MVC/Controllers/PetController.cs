using Microsoft.AspNetCore.Mvc;
using MVC.Helper;
using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class PetController : Controller
    {
        string Baseurl = "http://localhost:51028";
        public async Task<ActionResult> Index()
        {
            List<Pet> PetInfo = new List<Pet>();

            using (var pet = new HttpClient())

            {
                //Passing service base url  
                pet.BaseAddress = new Uri(Baseurl);

                pet.DefaultRequestHeaders.Clear();
                //Define request data format  
                pet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await pet.GetAsync("api/pet");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var petResponse = Res.Content.ReadAsStringAsync().Result;


                    //Deserializing the response recieved from web api and storing into the Employee list  
                    PetInfo = JsonConvert.DeserializeObject<List<Pet>>(petResponse);

                }
                //returning the employee list to view  
                return View(PetInfo);
            }
        }

        public async Task<ActionResult> Details(int id)
        {

            Pet PetInfo = new Pet();

            using (var pet = new HttpClient())

            {
                pet.BaseAddress = new Uri(Baseurl);

                pet.DefaultRequestHeaders.Clear();

                pet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await pet.GetAsync($"api/pet/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var petResponse = Res.Content.ReadAsStringAsync().Result;


                    PetInfo = JsonConvert.DeserializeObject<Pet>(petResponse);

                }

                return View(PetInfo);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pet petModel)
        {

            Pet PetInfo = new Pet();

            using (var pet = new HttpClient())

            {
                pet.BaseAddress = new Uri(Baseurl);

                pet.DefaultRequestHeaders.Clear();

                pet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var postTask = pet.PostAsJsonAsync<Pet>("api/pet", petModel);
                postTask.Wait();

                var Res = postTask.Result;

                if (Res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }

                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {

            Pet PetInfo = new Pet();

            using (var pet = new HttpClient())

            {
                pet.BaseAddress = new Uri(Baseurl);

                pet.DefaultRequestHeaders.Clear();

                pet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await pet.GetAsync($"api/pet/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var petResponse = Res.Content.ReadAsStringAsync().Result;


                    PetInfo = JsonConvert.DeserializeObject<Pet>(petResponse);

                }

                return View(PetInfo);
            }
        }

        
        [HttpPost]
        public  ActionResult Edit(int id, Pet petModel)
        {
            Pet PetInfo = new Pet();

            using (var pet = new HttpClient())

            {
                pet.BaseAddress = new Uri(Baseurl);

                pet.DefaultRequestHeaders.Clear();

                pet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var postTask = pet.PutAsJsonAsync<Pet>("api/pet", petModel);

                postTask.Wait();

                var Res = postTask.Result;

                
                    return RedirectToAction("Index");

            }
        }

        

        public async Task<ActionResult> Delete(int id)
        {
            Pet PetInfo = new Pet();

            using (var pet = new HttpClient())
            {
                pet.BaseAddress = new Uri(Baseurl);

                pet.DefaultRequestHeaders.Clear();

                pet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await pet.DeleteAsync($"api/pet/{id}");

            }

            return RedirectToAction("Index");

        }
    }
}
