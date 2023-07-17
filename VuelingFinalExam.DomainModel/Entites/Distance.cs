using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingFinalExam.DomainModel.Entites
{
    public class Distance
    {
        public int Id { get;}
        public string OriginPlanetCode { get; set; } //Corresponde a TAT, NAL, etc. en tu JSON
        public string DestinationPlanetCode { get; set; } //Corresponde a ALD, YAV, etc. en tu JSON
        public double LunarYears { get; set; }
    }
}
