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
        {/*
            try
            {
                if (imageListBoxCulomn1.SelectedItem == null && imageListBoxCulomn0.SelectedItem == null && imageListBoxCulomn0.SelectedItem == null) throw new ArgumentException("you have to selct the card to change the column");
                
                if(imageListBoxCulomn1.SelectedItem != null)
                Card selctedCard = imageListBoxCulomn0.SelectedItem as Card;

            }*/

        }

        private void lbxChangeFocusable(object sender, RoutedEventArgs e)
        {
            


        }
        /*
        private void lbxGotFocusColumn0(object sender, MouseEventArgs e)
        {
            lbxImageCulomn0.SelectedItem = null;
        }*/

        private void lbxLostFocusColumn0(object sender, RoutedEventArgs e)
        {
            if(btnColumn1.IsFocused || btnColumn2.IsFocused || btnColumn3.IsFocused || btnColumn4.IsFocused)
            {
                Card moveCard = 
                _match.MovCardsToColumnX()
            }
            lbxImageCulomn0.SelectedItem = null;
        }

        private void lbxLostFocusColumn1(object sender, RoutedEventArgs e)
        {
            lbxImageCulomn1.SelectedItem = null;

        }
    }
}
