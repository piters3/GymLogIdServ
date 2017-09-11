using System;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace GymLog.Client.Controllers {
    public class MusclesController : Controller
    {
      /*  HttpClient client;

        string url = GymLogConstants.API + "api/muscles";


        public MusclesController() {
            client = new HttpClient() {
                BaseAddress = new Uri(url),          
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }*/

     /*   public async Task<ActionResult> Index() {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode) {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var muscles = JsonConvert.DeserializeObject<List<MuscleModel>>(responseData);

                return View(muscles);
            }
            return Content("An error occurred.");
        }*/

      /*  private async Task<String> Index() {
            var user = User as ClaimsPrincipal;
            var token = user.FindFirst("access_token").Value;

            var client = new HttpClient();
            client.SetBearerToken(token);

            HttpResponseMessage response = await client.GetAsync(GymLogConstants.API+ "api/muscles");

            return await response.Content.ReadAsStringAsync();
        }*/
    }
}