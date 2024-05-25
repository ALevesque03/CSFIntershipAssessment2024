using System.Reflection.PortableExecutable;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Model;
using System.Net.Http.Headers;

namespace Service
{
    public class AnimalService
    {
        private readonly HttpClient httpClient = new();

        //Get 10 animals by name. The API I have chosen unfortunately does not have the option to search for all animals.
        //This is understandable as the database for the animals api seems to be very massive. Please feel free to change the name parameter to any animal species for other results.
        //An other option I could take is to give it a random set of animals each search.
        /// <summary>
        /// Gets 10 results of animal by name parameter given in API request.
        /// </summary>
        /// <param name="apiKey">This API requires a specific apiKey to access data, key value is given in function call</param>
        /// <returns>List of animals by search query</returns>
        public async Task<List<Animal>> GetAnimalsAsync(string apiKey, string searchString)
        {
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

            var response = await httpClient.GetStringAsync($"https://api.api-ninjas.com/v1/animals?name={searchString}");
            var animals = JsonConvert.DeserializeObject<List<Animal>>(response);
            return animals;
        }
    }
}