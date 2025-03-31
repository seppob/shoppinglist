using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Ostoslista
{
    public partial class MainWindow : Window
    {
        private List<Ostos> ostoslista = new List<Ostos>();

        public MainWindow()
        {
            InitializeComponent();
            btnPoista.IsEnabled = true;
        }

        private void btnLisaa_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTuote.Text) && int.TryParse(txtMaara.Text, out int maara))
            {
                Ostos uusiOstos = new Ostos { Tuote = txtTuote.Text, Maara = maara };
                ostoslista.Add(uusiOstos);
                lvOstoslista.Items.Add(uusiOstos);
                txtTuote.Clear();
                txtMaara.Clear();
            }
            else
            {
                MessageBox.Show("Syötä kelvollinen tuotenimi ja numero määrä!", "Virhe", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnPoista_Click(object sender, RoutedEventArgs e)
        {
            if (lvOstoslista.SelectedItem is Ostos valittu)
            {
                ostoslista.Remove(valittu);
                lvOstoslista.Items.Remove(valittu);
            }
        }

        private void btnTyhjenna_Click(object sender, RoutedEventArgs e)
        {
            ostoslista.Clear();
            lvOstoslista.Items.Clear();
        }

        private void btnTallenna_Click(object sender, RoutedEventArgs e)
        {
            // Luodaan SaveFileDialog
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            // Asetetaan oletustiedoston nimi ja tiedostopäätteet
            saveFileDialog.FileName = "ostoslista.txt";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            // Tarkistetaan, että käyttäjä valitsi tiedoston ja ei peruuta
            if (saveFileDialog.ShowDialog() == true)
            {
                // Tiedoston nimi ja polku
                string tiedostoPolku = saveFileDialog.FileName;

                // Luodaan StringBuilder tallentamista varten
                StringBuilder sb = new StringBuilder();

                // Käydään läpi ostoslista ja lisätään tiedot StringBuilderiin
                foreach (var ostos in ostoslista)
                {
                    sb.AppendLine($"{ostos.Tuote} ({ostos.Maara})");
                }

                // Tallennetaan tiedosto
                System.IO.File.WriteAllText(tiedostoPolku, sb.ToString());

                // Ilmoitetaan käyttäjälle tallennuksen onnistumisesta
                MessageBox.Show("Tiedosto tallennettu onnistuneesti!", "Tallennus", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }



        private void btnLataa_Click(object sender, RoutedEventArgs e)
        {
            // Luodaan OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            // Asetetaan tiedostopäätteet ja suodatin
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            // Tarkistetaan, että käyttäjä valitsi tiedoston ja ei peruuta
            if (openFileDialog.ShowDialog() == true)
            {
                // Tiedoston polku
                string tiedostoPolku = openFileDialog.FileName;

                // Luetaan tiedoston sisältö
                string[] tuotteet = System.IO.File.ReadAllLines(tiedostoPolku);

                // Tyhjennetään nykyinen lista ja lisätään tiedoston tuotteet
                ostoslista.Clear();
                lvOstoslista.Items.Clear();

                foreach (string tuote in tuotteet)
                {
                    // Jaetaan tuote ja määrä
                    string[] osat = tuote.Split('(');
                    if (osat.Length == 2)
                    {
                        string tuoteNimi = osat[0].Trim();
                        string maaraString = osat[1].Replace(")", "").Trim();

                        if (int.TryParse(maaraString, out int maara))
                        {
                            Ostos uusiOstos = new Ostos { Tuote = tuoteNimi, Maara = maara };
                            ostoslista.Add(uusiOstos);
                            lvOstoslista.Items.Add(uusiOstos);
                        }
                    }
                }

                // Ilmoitetaan käyttäjälle, että tiedosto on ladattu
                MessageBox.Show("Tiedosto ladattu onnistuneesti!", "Lataus", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


    }

    public class Ostos
    {
        public string Tuote { get; set; }
        public int Maara { get; set; }
    }
}
