using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingFinalExam.DomainModel.Entites
{
    public class SpyReport
    {
        public int Id { get; set; }

        [JsonProperty("code")]
        public string PlanetCode { get; set; }

        [JsonProperty("rebelInfluence")]
        public int RebelInfluence { get; set; }
    }

}
