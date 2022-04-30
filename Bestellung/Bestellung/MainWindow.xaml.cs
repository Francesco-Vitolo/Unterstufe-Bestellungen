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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bestellung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Karte Speisekarte = new Karte();
        Gericht[] BestellteSpeisen = new Gericht[3];
        int[] AlleMengen = new int[3];
        string gutschein;
        public MainWindow()
        {
            //var preise = PanelPreiseGesamt.Children.OfType<TextBlock>();

            InitializeComponent();
            TextSpeisen1.DataContext = Speisekarte.Speisekarte[0];
            TextSpeisen2.DataContext = Speisekarte.Speisekarte[1];
            TextSpeisen3.DataContext = Speisekarte.Speisekarte[2];

            TextPreis1.DataContext = Speisekarte.Speisekarte[0];
            TextPreis2.DataContext = Speisekarte.Speisekarte[1];
            TextPreis3.DataContext = Speisekarte.Speisekarte[2];
        }

        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            TextBox text = (TextBox)sender;
            int menge = Convert.ToInt32(text.Text);
            AlleMengen[0] = menge;
            double preis = Convert.ToDouble(TextPreis1.Text);
            double ergebnis = preis * menge;
            TextGesamtPreis1.Text = ergebnis.ToString();
        }

        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            TextBox text = (TextBox)sender;
            int menge = Convert.ToInt32(text.Text);
            AlleMengen[1] = menge;
            double preis = Convert.ToDouble(TextPreis2.Text);
            double ergebnis = preis * menge;
            TextGesamtPreis2.Text = ergebnis.ToString();
        }

        private void TextBox_TextChanged3(object sender, TextChangedEventArgs e)
        {
            TextBox text = (TextBox)sender;
            int menge = Convert.ToInt32(text.Text);
            AlleMengen[2] = menge;
            double preis = Convert.ToDouble(TextPreis3.Text);
            double ergebnis = preis * menge;
            TextGesamtPreis3.Text = ergebnis.ToString();
        }
        private void Button_Click_Bestellen(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;
            ButtonPreisBestellung_Click(clicked, e);
            string name = KundeName.Text;
            string adresse = KundeAdresse.Text;
            Kunde Kunde1 = new Kunde(name, adresse);


            Order bestellung1 = new Order(Kunde1, AlleMengen, BestellteSpeisen, gutschein);
            Bestellübersicht FensterÜbersicht = new Bestellübersicht(bestellung1);
            FensterÜbersicht.Show();
        }

        private void Button_Click_Abbrechen(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;
            MessageBox.Show("Bestellung wurde abgebrochen");
        }

        private void ButtonPreisBestellung_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;
            double pos1 = 0;
            double pos2 = 0;
            double pos3 = 0;

            if (TextGesamtPreis1.Text != "")
            {
                pos1 = Convert.ToDouble(TextGesamtPreis1.Text);
                BestellteSpeisen[0] = Speisekarte.Speisekarte[0];
            }
            else
            {
                Anzahl1.Text = 0.ToString();
            }

            if (TextGesamtPreis2.Text != "")
            {
                pos2 = Convert.ToDouble(TextGesamtPreis2.Text);
                BestellteSpeisen[1] = Speisekarte.Speisekarte[1];

            }
            else
            {
                Anzahl2.Text = 0.ToString();
            }

            if (TextGesamtPreis3.Text != "")
            {
                pos3 = Convert.ToDouble(TextGesamtPreis3.Text);
                BestellteSpeisen[2] = Speisekarte.Speisekarte[2];

            }
            else
            {
                Anzahl3.Text = 0.ToString();
            }

            double ergebnis = pos1 + pos2 + pos3;
            TextPreisBestellung.Text = ergebnis.ToString();
        }

        private void Gutscheincode_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox code = (TextBox)sender;
            gutschein = code.Text.ToString();
        }

        private void ButtonGutscheinPrüfen_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;            
            if (Eingabe_Gutschein.Text == "Nickgür")
            {
                GutscheinAktiviert.Text = "Gutschein ist aktiv";
            }
            else
            {
                GutscheinAktiviert.Text = "ungültig";
            }
        }
    }
}
