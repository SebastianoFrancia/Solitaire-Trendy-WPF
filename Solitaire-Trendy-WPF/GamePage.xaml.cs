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

namespace Solitaire_Trendy_WPF
{
    /// <summary>
    /// Logica di interazione per GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private string name;
        public GamePage(string nome)
        {
            InitializeComponent();
            btnCarta.Visibility = Visibility.Hidden;
            name = nome;
            Init();
        }

        public void Init()
        {
            List<Card> base1 = new List<Card>();
            List<Card> base2 = new List<Card>();
            List<Card> base3 = new List<Card>();
            List<Card> base4 = new List<Card>();
            Match match = new Match(name);
        }

        private void btnMazzoGeneraCarte_Click(object sender, RoutedEventArgs e)
        {
            btnCarta.Visibility = Visibility.Visible;
        }

        private void btnCarta_Click(object sender, RoutedEventArgs e)
        {
            btnSpostamentoCln1.IsEnabled = true;
            btnSpostamentoCln2.IsEnabled = true;
            btnSpostamentoCln3.IsEnabled = true;
            btnSpostamentoCln4.IsEnabled = true;

            asodiugyasdeayso8fguaysiduegyaseiufya
            btnSpostamentoCln5.IsEnabled = true;
        }
    }
}
