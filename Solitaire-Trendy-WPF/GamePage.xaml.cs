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
        public Match _match;
        public GamePage(string nome)
        {
            InitializeComponent();
            btnCarta.Visibility = Visibility.Hidden;
            _match = new Match(nome);

            lbxImageCulomn0.ItemsSource = ColumnImage(0);
            lbxImageCulomn1.ItemsSource = ColumnImage(1);
            lbxImageCulomn2.ItemsSource = ColumnImage(2);
            lbxImageCulomn3.ItemsSource = ColumnImage(3);
            lbxImageCulomn4.ItemsSource = ColumnImage(4);
        }

        public List<BitmapImage> ColumnImage(int columnX)
        {
            List<BitmapImage> imgListOfCards = new List<BitmapImage>();

            foreach (Card card in _match.CardsOfColumnX(columnX))
            {
                BitmapImage img = GetImageOfCard(card);
                imgListOfCards.Add(img);
            }
            return imgListOfCards;
        }


        private BitmapImage GetImageOfCard(Card card)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = card.ImagePathCard;
            img.EndInit();
            return img;
        }



        private void btnDeckFishCard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Card extractedCard = _match.CardDraw();

                BitmapImage imgCard = GetImageOfCard(extractedCard);
                ImageBrush imageBrush = new ImageBrush(imgCard);
                btnCarta.Background = imageBrush;

                btnCarta.Visibility = Visibility.Visible;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
        private void btnCarta_Click(object sender, RoutedEventArgs e)
        {
            //_match.IsInsertableCardOnBase(_match.LastCardDrawn);


        }

        private void btnColumn0_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(lbxImageCulomn1.SelectedItem != null)
                {
                    _match.MovCardsToColumnX(1, 0, (Card)lbxImageCulomn1.SelectedItem);
                }
                if (lbxImageCulomn2.SelectedItem != null)
                {
                    _match.MovCardsToColumnX(2, 0, (Card)lbxImageCulomn1.SelectedItem);
                }
                if (lbxImageCulomn3.SelectedItem != null)
                {
                    _match.MovCardsToColumnX(3, 0, (Card)lbxImageCulomn1.SelectedItem);
                }
                if (lbxImageCulomn4.SelectedItem != null)
                {
                    _match.MovCardsToColumnX(4,0 , (Card)lbxImageCulomn1.SelectedItem);
                }

            }catch

        }

        private void lbxChangeFocusable(object sender, RoutedEventArgs e)
        {
            


        }

        private void lbxLostFocusColumn0(object sender, RoutedEventArgs e)
        {
            if( !(btnColumn1.IsMouseOver || btnColumn2.IsMouseOver || btnColumn3.IsMouseOver || btnColumn4.IsMouseOver) )
            {
                lbxImageCulomn0.SelectedItem = null;
            }
            
             
        }

        private void lbxLostFocusColumn1(object sender, RoutedEventArgs e)
        {
            if (!(btnColumn0.IsMouseOver || btnColumn2.IsMouseOver || btnColumn3.IsMouseOver || btnColumn4.IsMouseOver))
            {
                lbxImageCulomn1.SelectedItem = null;
            }

        }

        private void lbxLostFocusColumn2(object sender, RoutedEventArgs e)
        {
            if (!(btnColumn1.IsMouseOver || btnColumn0.IsMouseOver || btnColumn3.IsMouseOver || btnColumn4.IsMouseOver))
            {
                lbxImageCulomn2.SelectedItem = null;
            }
        }

        private void lbxLostFocusColumn3(object sender, RoutedEventArgs e)
        {
            if (!(btnColumn1.IsMouseOver || btnColumn2.IsMouseOver || btnColumn0.IsMouseOver || btnColumn4.IsMouseOver))
            {
                lbxImageCulomn3.SelectedItem = null;
            }
        }

        private void lbxLostFocusColumn4(object sender, RoutedEventArgs e)
        {
            if (!(btnColumn1.IsMouseOver || btnColumn2.IsMouseOver || btnColumn3.IsMouseOver || btnColumn0.IsMouseOver))
            {
                lbxImageCulomn4.SelectedItem = null;
            }
        }
    }
}
