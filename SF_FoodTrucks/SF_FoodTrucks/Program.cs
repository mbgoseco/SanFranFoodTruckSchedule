using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SF_FoodTrucks.Controller;
using SF_FoodTrucks.Models;

namespace SF_FoodTrucks
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Instantiates the HttpClient for the duration of the application and calls the methods to get and display list of open food trucks.
        /// </summary>
        /// <returns></returns>
        static async Task RunAsync()
        {
            HttpClient client = new HttpClient();
            
            client.BaseAddress = new Uri("https://data.sfgov.org/resource/bbb8-hzi6.geojson");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            FoodTruckController controller = new FoodTruckController(client);
            List<ResultsList> openFoodTrucks = await controller.GetFoodTrucks();

        }
    }
}
