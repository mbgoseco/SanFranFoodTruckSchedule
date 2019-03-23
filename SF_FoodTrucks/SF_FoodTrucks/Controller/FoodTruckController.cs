using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using SF_FoodTrucks.Model;

namespace SF_FoodTrucks.Controller
{
    public class FoodTruckController
    {
        public string Uri { get; set; }

        public FoodTruckController(string uri)
        {
            Uri = uri;
        }

        public async Task<List<FoodTruck>> GetFoodTrucks()
        {

        }
    }
}
