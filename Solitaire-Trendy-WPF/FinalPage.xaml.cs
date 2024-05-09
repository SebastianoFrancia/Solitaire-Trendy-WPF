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
    /// Logica di interazione per FinalPage.xaml
    /// </summary>
    public partial class FinalPage : Page
    {
        private string _name;
        public FinalPage(string name)
        {
            InitializeComponent();
            _name = name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GamePage page = new GamePage(_name);
            ((MainWindow)Application.Current.MainWindow).ChangePage(page);
        }
    }
}
