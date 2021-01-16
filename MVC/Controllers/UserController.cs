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
    public class UserController : Controller
    {
        string Baseurl = "http://localhost:54200";
        public async Task<ActionResult> Index()
        {
            List<User> UserInfo = new List<User>();

            using (var user = new HttpClient())

            {
                user.BaseAddress = new Uri(Baseurl);

                user.DefaultRequestHeaders.Clear();

                user.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await user.GetAsync("api/user");

                if (Res.IsSuccessStatusCode)
                {
                    var userResponse = Res.Content.ReadAsStringAsync().Result;

                    UserInfo = JsonConvert.DeserializeObject<List<User>>(userResponse);

                }
                //returning the employee list to view  
                return View(UserInfo);
            }
        }

        public async Task<ActionResult> Details(int id)
        {

            User userInfo = new User();

            using (var user = new HttpClient())

            {
                user.BaseAddress = new Uri(Baseurl);

                user.DefaultRequestHeaders.Clear();

                user.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await user.GetAsync($"api/User/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var userResponse = Res.Content.ReadAsStringAsync().Result;


                    userInfo = JsonConvert.DeserializeObject<User>(userResponse);

                }

                return View(userInfo);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User userModel)
        {

            User userInfo = new User();

            using (var user = new HttpClient())

            {
                user.BaseAddress = new Uri(Baseurl);

                user.DefaultRequestHeaders.Clear();

                user.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var postTask = user.PostAsJsonAsync<User>("api/user", userModel);
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

            User userInfo = new User();

            using (var user = new HttpClient())

            {
                user.BaseAddress = new Uri(Baseurl);

                user.DefaultRequestHeaders.Clear();

                user.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await user.GetAsync($"api/user/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var userResponse = Res.Content.ReadAsStringAsync().Result;


                    userInfo = JsonConvert.DeserializeObject<User>(userResponse);

                }

                return View(userInfo);
            }
        }

        
        [HttpPost]
        public  ActionResult Edit(int id, User userModel)
        {
            User userInfo = new User();

            using (var user = new HttpClient())

            {
                user.BaseAddress = new Uri(Baseurl);

                user.DefaultRequestHeaders.Clear();

                user.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var postTask = user.PutAsJsonAsync<User>("api/user", userModel);

                postTask.Wait();

                var Res = postTask.Result;

                
                    return RedirectToAction("Index");

            }
        }

        

        public async Task<ActionResult> Delete(int id)
        {
            User userInfo = new User();

            using (var user = new HttpClient())
            {
                user.BaseAddress = new Uri(Baseurl);

                user.DefaultRequestHeaders.Clear();

                user.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await user.DeleteAsync($"api/user/{id}");

            }

            return RedirectToAction("Index");

        }
    }
}
