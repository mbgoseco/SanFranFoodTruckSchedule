using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using SF_FoodTrucks.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Globalization;

namespace SF_FoodTrucks.Controller
{
    public class FoodTruckController
    {
        private readonly HttpClient _client;

        public FoodTruckController(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Generates a list of food trucks by name and address from the JSON object returned by the API call, and filters the results by businesses that are currently open.
        /// </summary>
        /// <returns>List of food trucks open at the time of the API call</returns>
        public async Task<List<ResultsList>> GetFoodTrucks()
        {
            List<ResultsList> results = new List<ResultsList>();

            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                FoodTrucks.Rootobject list = JsonConvert.DeserializeObject<FoodTrucks.Rootobject>(await response.Content.ReadAsStringAsync());

                var query = from n in list.features
                                 select n.properties;

                var openFoodTrucks = await FilterOpenFoodTrucks(query);

                foreach (var item in openFoodTrucks)
                {
                    ResultsList foodTruck = new ResultsList();
                    foodTruck.Name = item.applicant;
                    foodTruck.Address = item.location;
                    results.Add(foodTruck);
                }
            }

            return results;
        }

        /// <summary>
        /// Queries the deserialized JSON object for food trucks that are currently open at the day and time of the API call and returns them as a list.
        /// </summary>
        /// <param name="list">Queryable list from JSON object</param>
        /// <returns>List of food trucks currently open</returns>
        public async Task<List<FoodTrucks.Properties1>> FilterOpenFoodTrucks(IEnumerable<FoodTrucks.Properties1> list)
        {
            List<FoodTrucks.Properties1> filteredList = new List<FoodTrucks.Properties1>();
            string current = $"{DateTime.Now.TimeOfDay.Hours.ToString("00.##")}" +
                $"{DateTime.Now.TimeOfDay.Minutes.ToString("00.##")}";


            IEnumerable<FoodTrucks.Properties1> filterByOpenDay = list.Where(t => t.dayofweekstr.ToUpper() == DateTime.Today.DayOfWeek.ToString().ToUpper());
            foreach (var item in filterByOpenDay)
            {
                string open = "";
                for (int i = 0; i < item.start24.Length; i++)
                {
                    if (item.start24[i] != ':')
                    {
                        open += item.start24[i];
                    }
                }

                string closed = "";
                for (int i = 0; i < item.end24.Length; i++)
                {
                    if (item.end24[i] != ':')
                    {
                        closed += item.end24[i];
                    }
                }

                if (Convert.ToInt32(current) > Convert.ToInt32(open) && Convert.ToInt32(current) < Convert.ToInt32(closed))
                {
                    filteredList.Add(item);
                }
            }

            return filteredList;
        }
    }
}
