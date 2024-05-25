using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using System.Text;

namespace Web.Controllers
{
    public class FormController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7293");

            var response = await client.GetStringAsync("/api/Form");

            List<Form> forms = JsonConvert.DeserializeObject<List<Form>>(response);
            

            return View(forms);
        }

        [HttpGet]
        public async Task<ActionResult> Detail(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7293");

            var response = await client.GetStringAsync($"/api/Form/{id}");

            Form form = JsonConvert.DeserializeObject<Form>(response);


            return View(form);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            Form form = new Form();

            return View(form);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Form form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7293");

            //Pass in the values from the form to create the form
            var queryString = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", form.Name),
                new KeyValuePair<string, string>("owned", form.Owned.ToString()),
                new KeyValuePair<string, string>("goodPet", form.GoodPet.ToString().ToLower())
            }).ReadAsStringAsync().Result;

            HttpResponseMessage response = await client.PostAsync($"/api/Form?{queryString}", null);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                int returnedId = JsonConvert.DeserializeObject<int>(responseData);
                ViewBag.SuccessfulCreation = $"Form has been created with ID: {returnedId}";
                // Redirect to the details page for that form that was created
                return RedirectToAction("Detail", new { id = returnedId });
            }
            else
            {
                // Handle the error as needed
                ModelState.AddModelError(string.Empty, "An error occurred while creating the form.");
                return View(form);
            }
        }
    }
}
