using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestellung
{
    public class Kunde
    {
        public string name { get; set; }
        public string adresse { get; set; }

        public Kunde(string name, string adresse)
        {
            this.name = name;
            this.adresse = adresse;
        }
    }
}