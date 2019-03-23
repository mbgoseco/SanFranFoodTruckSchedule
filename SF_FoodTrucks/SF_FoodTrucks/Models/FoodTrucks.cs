using System;

namespace SF_FoodTrucks.Models
{
    public class FoodTrucks
    {
        public class Rootobject
        {
            public string Type { get; set; }
            public Feature[] Features { get; set; }
            public Crs Crs { get; set; }
        }

        public class Crs
        {
            public string Type { get; set; }
            public Properties Properties { get; set; }
        }

        public class Properties
        {
            public string Name { get; set; }
        }

        public class Feature
        {
            public string Type { get; set; }
            public Geometry Geometry { get; set; }
            public Properties1 Properties { get; set; }
        }

        public class Geometry
        {
            public string Type { get; set; }
            public float[] Coordinates { get; set; }
        }

        public class Properties1
        {
            public string X { get; set; }
            public object Location_2_state { get; set; }
            public string Applicant { get; set; }
            public string Location { get; set; }
            public string Latitude { get; set; }
            public string Y { get; set; }
            public string Computed_region_yftq_j783 { get; set; }
            public object Location_2_zip { get; set; }
            public string Locationid { get; set; }
            public string Dayofweekstr { get; set; }
            public string Coldtruck { get; set; }
            public DateTime Addr_date_create { get; set; }
            public string Start24 { get; set; }
            public string Cnn { get; set; }
            public string Longitude { get; set; }
            public string Optionaltext { get; set; }
            public string Computed_region_rxqg_mtj9 { get; set; }
            public string Dayorder { get; set; }
            public string Computed_region_ajp5_b2md { get; set; }
            public string Block { get; set; }
            public object Location_2_city { get; set; }
            public string Endtime { get; set; }
            public object Scheduleid { get; set; }
            public string Permit { get; set; }
            public DateTime? Addr_date_modified { get; set; }
            public string Locationdesc { get; set; }
            public string Computed_region_bh8s_q3mv { get; set; }
            public string Starttime { get; set; }
            public string Lot { get; set; }
            public string Computed_region_jx4q_fizf { get; set; }
            public object Location_2_address { get; set; }
            public string End24 { get; set; }
        }
    }
}
