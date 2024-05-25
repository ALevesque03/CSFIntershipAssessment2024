using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using System.Text.Json.Serialization;

namespace CSharp_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalService animalService = new AnimalService();

        //The generic get function to return 10 parrots. It returns 10 parrots as the API does not have the option to search without a name parameter.
        [HttpGet]
        public async Task<ActionResult<List<Animal>>> Get(string searchString = "Parrot")
        {
            try
            {
                string apiKey = "ebKwYGANnfIfb103+RocFw==u9hizQrNM7TF95dX";
                List<Animal> animals = await animalService.GetAnimalsAsync(apiKey, searchString);
                return animals;
            }
            catch (Exception ex)
            {
                return Problem(title: $"An internal error has occured. {ex}");
            }
        }
    }
}
