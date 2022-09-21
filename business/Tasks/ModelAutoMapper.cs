using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace business.Tasks
{
    public class ModelAutoMapper
    {
        [JsonPropertyName("Name")]
        public String Name { get; set; }

        [JsonPropertyName("DOB")]
        public DateTime DOB { get; set; }

        [JsonPropertyName("Major")]
        public string Major { get; set; }

        [JsonPropertyName("Andress")]
        public String Andress { get; set; }

        [JsonPropertyName("Phone")]
        public int Phone { get; set; }

        [JsonPropertyName("DateCreate")]
        public DateTime DateCreate { get; set; }

        [JsonPropertyName("DateUpdate")]
        public DateTime DateUpdate { get; set; }


    }
}

