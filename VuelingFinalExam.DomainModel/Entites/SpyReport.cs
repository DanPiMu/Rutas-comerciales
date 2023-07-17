using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingFinalExam.DomainModel.Entites
{
    public class SpyReport
    {
        public int Id { get;}
        public string PlanetCode { get; set; } //Corresponde a TAT, ORD, etc. en tu JSON
        public int RebelInfluence { get; set; }
    }
}
