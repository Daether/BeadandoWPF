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

namespace Beadando
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {/// <summary>
    /// Számlák listája
    /// </summary>
        List<Invoice> invoice = new List<Invoice>();

        //Invoice i = new Invoice();
        /// <summary>
        /// Core osztály példánya
        /// </summary>
        Core c = new Core();
        /// <summary>
        /// segédváltozó visszatérési értékekhez
        /// </summary>
        int ertek;

        /// <summary>
        /// Új invoice adatokat rögzít, GUI-t rajzol
        /// </summary>
        public MainWindow()
        {
            invoice.Add(new Invoice { OwnerName = "Alfa"});
            invoice.Add(new Invoice { OwnerName = "Beta"});
            InitializeComponent();

            TBoxU1.Text = invoice[0].OwnerName;
            TBoxU2.Text = invoice[1].OwnerName;
            TBoxL1.Text = invoice[0].Balance.ToString();
            TBoxL2.Text = invoice[1].Balance.ToString();
        }

        /// <summary>
        /// Baloldali Feltöltés gomb eseményét definiálja
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Esemény, ami bekövetkezett</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            ertek = c.Feltolt(TextBoxWrL.Text, TBoxL1.Text);
           
            if (ertek!=-1)
            {
                invoice[0].Balance = ertek;
                TBoxL1.Text = invoice[0].Balance.ToString();

            }
            else 
            {
                MessageBox.Show("Kérem adjon meg pozitív számot!", "Sikertelen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        /// <summary>
        /// Jobboldali Feltöltés gomb eseményét definiálja
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Esemény, ami bekövetkezett</param>
        private void Upload2(object sender, RoutedEventArgs e)
        {
            ertek = c.Feltolt(TextBoxWrR.Text, TBoxL2.Text);
            if (ertek!=-1)
            {
                invoice[1].Balance = ertek;
                TBoxL2.Text = invoice[1].Balance.ToString();

            }
            else
            {
                MessageBox.Show("Kérem adjon meg pozitív számot!", "Sikertelen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Baloldali Kivét gomb eseményét definiálja
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Esemény, ami bekövetkezett</param>
        private void KivetelAlfa(object sender, RoutedEventArgs e)
        {
            ertek = c.Kivesz(TBoxL1.Text, TextBoxWrL.Text);
            if (ertek != -1)
            {
                invoice[0].Balance = ertek;
                TBoxL1.Text = invoice[0].Balance.ToString();
            }
            else
            {
                MessageBox.Show("Kérem adjon meg pozitív számot, vagy kisebb számot, mint az egyenlege!", "Sikertelen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Jobboldali Kivét gomb eseményét definiálja
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Esemény, ami bekövetkezett</param>
        private void KivetelBeta(object sender, RoutedEventArgs e)
        {
            ertek = c.Kivesz(TBoxL2.Text, TextBoxWrR.Text);
            if (ertek != -1)
            {
                invoice[0].Balance = ertek;
                TBoxL2.Text = invoice[0].Balance.ToString();

            }
            else
            {
                MessageBox.Show("Kérem adjon meg pozitív számot, vagy kisebb számot, mint az egyenlege!", "Sikertelen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Baloldali Utalás gomb eseményét definiálja
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Esemény, ami bekövetkezett</param>
        private void UtalasAlfa(object sender, RoutedEventArgs e)
        {
            //először kivonok a Balancebol
            //majd a másik Balancához hozzáadom

            string KivonasFeltoltes = TextBoxWrL.Text;
            ertek = c.Kivesz(TBoxL1.Text, TextBoxWrL.Text);
            if (ertek != -1)
            {
                invoice[0].Balance = ertek;
                TBoxL1.Text = invoice[0].Balance.ToString();

                ertek = c.Feltolt(KivonasFeltoltes, TBoxL2.Text);
                //if (!ertek.ToString().Contains("Exception"))
                //{
                    invoice[1].Balance = ertek;
                    TBoxL2.Text = invoice[1].Balance.ToString();

                //}
            }
            else
            {
                MessageBox.Show("Kérem adjon meg pozitív számot, vagy kisebb számot, mint az egyenlege!", "Sikertelen", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        /// <summary>
        /// Jobboldali Utalás gomb eseményét definiálja
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Esemény, ami bekövetkezett</param>
        private void UtalasBeta(object sender, RoutedEventArgs e)
        {
            string KivonasFeltoltes = TextBoxWrR.Text;
            ertek = c.Kivesz(TBoxL2.Text, TextBoxWrR.Text);
            if (ertek != -1)
            {
                invoice[1].Balance = ertek;
                TBoxL2.Text = invoice[1].Balance.ToString();

                ertek = c.Feltolt(KivonasFeltoltes, TBoxL1.Text);
                //if (!ertek.ToString().Contains("Exception"))
                //{
                    invoice[0].Balance = ertek;
                    TBoxL1.Text = invoice[0].Balance.ToString();

                //}

            }
            else
            {
                MessageBox.Show("Kérem adjon meg pozitív számot, vagy kisebb számot, mint az egyenlege!", "Sikertelen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Baloldali Tulaj név váltás gomb eseményét definiálja
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Esemény, ami bekövetkezett</param>
        private void TulajNevValtL(object sender, RoutedEventArgs e)
        {
            
                //TextBoxWrL jelenjeg meg TBoxU1-ben
                invoice[0].OwnerName = TextBoxWrL.Text;
                TBoxU1.Text = invoice[0].OwnerName;
           
            
        }
        /// <summary>
        /// Jobboldali Tulaj név váltás gomb eseményét definiálja
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Esemény, ami bekövetkezett</param>
        private void TulajNevValtR(object sender, RoutedEventArgs e)
        {
            invoice[1].OwnerName = TextBoxWrR.Text;
            TBoxU2.Text = invoice[1].OwnerName;
        }
    }
}
