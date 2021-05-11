using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WF_WeatherHTTP_API
{
  
    public class Rain
    {

        [JsonProperty("1h")]
        public double h1 { get; set; }
    } 

    public class Weather
    {

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("main")]
        public string main { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("icon")]
        public string icon { get; set; }
    }
    public class Hourly
    {

        [JsonProperty("dt")]
        public int dt { get; set; }

        [JsonProperty("temp")]
        public double temp { get; set; }

        [JsonProperty("feels_like")]
        public double feels_like { get; set; }

        [JsonProperty("pressure")]
        public int pressure { get; set; }

        [JsonProperty("humidity")]
        public int humidity { get; set; }

        [JsonProperty("dew_point")]
        public double dew_point { get; set; }

        [JsonProperty("uvi")]
        public double uvi { get; set; }

        [JsonProperty("clouds")]
        public int clouds { get; set; }

        [JsonProperty("visibility")]
        public int visibility { get; set; }

        [JsonProperty("wind_speed")]
        public double wind_speed { get; set; }

        [JsonProperty("wind_deg")]
        public int wind_deg { get; set; }

        [JsonProperty("wind_gust")]
        public double wind_gust { get; set; }

        [JsonProperty("weather")]
        public IList<Weather> weather { get; set; }

        [JsonProperty("pop")]
        public double pop { get; set; }

        [JsonProperty("rain")]
        public Rain rain { get; set; }
    }
    public class Whether_data
    {

        [JsonProperty("lat")]
        public double lat { get; set; }

        [JsonProperty("lon")]
        public double lon { get; set; }

        [JsonProperty("timezone")]
        public string timezone { get; set; }

        [JsonProperty("timezone_offset")]
        public int timezone_offset { get; set; }

        [JsonProperty("hourly")]
        public IList<Hourly> hourly { get; set; }
    }
}

