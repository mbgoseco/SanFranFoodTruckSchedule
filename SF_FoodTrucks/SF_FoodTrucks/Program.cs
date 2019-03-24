using System;
using System.Collections.Generic;
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
            PrintList(openFoodTrucks);
        }

        /// <summary>
        /// Prints the list of currently open food trucks to the console. List is printed 10 items at a time, pausing until the user presses Enter before printing the next 10 lines.
        /// </summary>
        /// <param name="list">List of open food trucks by name and address</param>
        static void PrintList(List<ResultsList> list)
        {
            int counter = 0;

            Console.WriteLine($"{"NAME", -75} {"ADDRESS", -20}");
            Console.WriteLine($"{"----", -75} {"-------", -20}");

            foreach (ResultsList item in list)
            {
                if (counter % 10 == 0 && counter != 0)
                {
                    Console.Write("Press ENTER to display next 10 results");
                    Console.ReadLine();
                }

                Console.WriteLine($"{item.Name,-75} {item.Address,-20}");
                counter++;
            }

            Console.WriteLine($"Found {list.Count} results for currently open food trucks.");
        }
    }
}
