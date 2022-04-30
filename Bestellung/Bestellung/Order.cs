using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestellung
{
    public class Order
    {
        public Kunde kunde1 { get; set; }
        public int[] AlleMengen { get; set; }
        public Gericht[] speisen { get; set; }

        public string gutschein { get; set; }

        public Order(Kunde k, int[] AlleMengen, Gericht[] speisen, string gutschein)
        {
            kunde1 = k;
            this.AlleMengen = AlleMengen;
            this.speisen = speisen;
            this.gutschein = gutschein;
        }

    }
}
