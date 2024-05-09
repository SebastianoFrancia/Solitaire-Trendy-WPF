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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users;
        public MainWindow()
        {
            InitializeComponent();
            ReadFile rd = new ReadFile("source/user.csv");
            users = rd.ReadUsers();

        }

        public void ChangePage(Page Page)
        {
            this.Content = Page;
        }


        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtInputName.Text;

                GamePage page = new GamePage(users);
                ChangePage(page);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ":\ncan't be empty and must be longher than three letters"); //"insert the name"

            }
        }
    }
}
