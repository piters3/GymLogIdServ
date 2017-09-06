using GymLog.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GymLog.Client.Controllers {
    public class MusclesController : Controller
    {
        HttpClient client;

        string url = "https://localhost:44390/api/muscles";


        public MusclesController() {
            client = new HttpClient() {
                BaseAddress = new Uri(url),          
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ActionResult> Index() {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode) {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var muscles = JsonConvert.DeserializeObject<List<MuscleModel>>(responseData);

                return View(muscles);
            }
            return Content("An error occurred.");
        }
    }
}