using System;
using System.Collections.Generic;
using System.Text;

namespace SF_FoodTrucks.Models
{
    public class FoodTrucks
    {
        public class Rootobject
        {
            public string type { get; set; }
            public Feature[] features { get; set; }
            public Crs crs { get; set; }
        }

        public class Crs
        {
            public string type { get; set; }
            public Properties properties { get; set; }
        }

        public class Properties
        {
            public string name { get; set; }
        }

        public class Feature
        {
            public string type { get; set; }
            public Geometry geometry { get; set; }
            public Properties1 properties { get; set; }
        }

        public class Geometry
        {
            public string type { get; set; }
            public float[] coordinates { get; set; }
        }

        public class Properties1
        {
            public string x { get; set; }
            public object location_2_state { get; set; }
            public string applicant { get; set; }
            public string location { get; set; }
            public string latitude { get; set; }
            public string y { get; set; }
            public string computed_region_yftq_j783 { get; set; }
            public object location_2_zip { get; set; }
            public string locationid { get; set; }
            public string dayofweekstr { get; set; }
            public string coldtruck { get; set; }
            public DateTime addr_date_create { get; set; }
            public string start24 { get; set; }
            public string cnn { get; set; }
            public string longitude { get; set; }
            public string optionaltext { get; set; }
            public string computed_region_rxqg_mtj9 { get; set; }
            public string dayorder { get; set; }
            public string computed_region_ajp5_b2md { get; set; }
            public string block { get; set; }
            public object location_2_city { get; set; }
            public string endtime { get; set; }
            public object scheduleid { get; set; }
            public string permit { get; set; }
            public DateTime? addr_date_modified { get; set; }
            public string locationdesc { get; set; }
            public string computed_region_bh8s_q3mv { get; set; }
            public string starttime { get; set; }
            public string lot { get; set; }
            public string computed_region_jx4q_fizf { get; set; }
            public object location_2_address { get; set; }
            public string end24 { get; set; }
        }
    }
}
