using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestellung
{
    public class Gericht
    {

        public string name { get; set; }
        public double preis { get; set; }


        public Gericht(string name, double preis)
        {
            this.name = name;
            this.preis = preis;
        }
    }


}
