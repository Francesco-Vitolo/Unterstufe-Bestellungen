using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestellung
{
    public class Karte
    {
        public Gericht[] Speisekarte;

        public Karte()
        {
            Speisekarte = new Gericht[5];
            Speisekarte[0] = new Gericht("Pizza Margherita", 5.80);
            Speisekarte[1] = new Gericht("Pizza Salami", 6.66);
            Speisekarte[2] = new Gericht("Pizza Funghi", 4.20);
        }
    }
}
