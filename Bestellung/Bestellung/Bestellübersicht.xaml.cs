using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bestellung
{
    /// <summary>
    /// Interaktionslogik für Bestellübersicht.xaml
    /// </summary>
    public partial class Bestellübersicht : Window
    {
        public string name { get; set; }
        public string adresse { get; set; }
        public int[] AlleMengen { get; set; }
        public Gericht[] speisen { get; set; }
        public string code { get; set; }
        int rabatt = 0;

        public Bestellübersicht(Order Bestellung)
        {          
            InitializeComponent();
            name = Bestellung.kunde1.name;
            adresse = Bestellung.kunde1.adresse;
            speisen = Bestellung.speisen;
            AlleMengen = Bestellung.AlleMengen;
            code = Bestellung.gutschein;
            Löschen();
            Kundenname.Text = name;
            Kundenadresse.Text = adresse;

            double preis = 0;
            if(AlleMengen[0] > 0)
            {
                 TextSpeisen1.DataContext = speisen[0];
                 Anzahl1.Text = AlleMengen[0].ToString();
                 TextGesamtPreis1.Text = (AlleMengen[0] * speisen[0].preis).ToString();
                 preis = preis + Convert.ToDouble(TextGesamtPreis1.Text);
            }

            if (AlleMengen[1] > 0)
            {
                TextSpeisen2.DataContext = speisen[1];
                Anzahl2.Text = AlleMengen[1].ToString();
                TextGesamtPreis2.Text = (AlleMengen[1] * speisen[1].preis).ToString();
                preis = preis + Convert.ToDouble(TextGesamtPreis2.Text);
            }


            if (AlleMengen[2] > 0)
            {
                TextSpeisen3.DataContext = speisen[2];
                Anzahl3.Text = AlleMengen[2].ToString();
                TextGesamtPreis3.Text = (AlleMengen[2] * speisen[2].preis).ToString();
                preis = preis + Convert.ToDouble(TextGesamtPreis3.Text);
            }



            if (code=="Nickgür")
            {
                rabatt = 10;
                Code.Text = "Code: ";
                Gutscheincode.Text = code;
            }

            PreisBerechnen(ref preis);
        }

        private void PreisBerechnen(ref double preis)
        {            
            if (rabatt > 0)
            {
                GutscheinRabatt.Text = "-" + Math.Round((preis * rabatt / 100), 2).ToString();
                preis = preis - (preis * rabatt / 100);
            }
            TextPreisBestellung.Text = preis.ToString();
        }

        private void Löschen()
        {
            if (AlleMengen[0] == 0)
            {
                TextSpeisen1.Visibility = Visibility.Collapsed;
                TextGesamtPreis1.Visibility = Visibility.Collapsed;
                Anzahl1.Visibility = Visibility.Collapsed;
            }

            if (AlleMengen[1] == 0)
            {
                TextSpeisen2.Visibility = Visibility.Collapsed;
                TextGesamtPreis2.Visibility = Visibility.Collapsed;
                Anzahl2.Visibility = Visibility.Collapsed;
            }


            if (AlleMengen[2] == 0)
            {
                TextSpeisen3.Visibility = Visibility.Collapsed;
                TextGesamtPreis3.Visibility = Visibility.Collapsed;
                Anzahl3.Visibility = Visibility.Collapsed;
            }
        }
    }
}
