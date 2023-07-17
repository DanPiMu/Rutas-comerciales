using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingFinalExam.DomainModel.Entites
{
    public class Price
    {
        public int Id { get;}
        public string Sector { get; set; }
        public double PricesPerLunarDay { get; set; }
    }
}
