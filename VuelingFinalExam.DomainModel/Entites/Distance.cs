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
        public string OriginPlanetCode { get; set; } 
        public string DestinationPlanetCode { get; set; } 
        public double LunarYears { get; set; }
    }
}
