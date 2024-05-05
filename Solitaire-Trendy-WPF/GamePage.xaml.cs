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

            lbxImageCulomn0.ItemsSource = _match.CardsOfColumnX(0);
            lbxImageCulomn1.ItemsSource = _match.CardsOfColumnX(1);
            lbxImageCulomn2.ItemsSource = _match.CardsOfColumnX(2);
            lbxImageCulomn3.ItemsSource = _match.CardsOfColumnX(3); 
            lbxImageCulomn4.ItemsSource = _match.CardsOfColumnX(4);
            
        }

        private void btnDeckFishCard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Card extractedCard = _match.CardDraw();

                btnCarta.Background = new ImageBrush(extractedCard.ImageCard);

                btnCarta.Visibility = Visibility.Visible;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCarta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Card drawnCard = _match.LastDrawnCard;
                if ( _match.IsInsertableCardOnBase(drawnCard) )
                {

                }    
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnColumn0_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (lbxImageCulomn1.SelectedItem != null)
                {
                    _match.MovCardsToColumnX(1, 0, (Card)lbxImageCulomn1.SelectedItem);
                }
                else if (lbxImageCulomn2.SelectedItem != null)
                {   
                    _match.MovCardsToColumnX(2, 0, (Card)lbxImageCulomn2.SelectedItem);
                }
                else if (lbxImageCulomn3.SelectedItem != null)
                {   
                    _match.MovCardsToColumnX(3, 0, (Card)lbxImageCulomn3.SelectedItem);
                }
                else if (lbxImageCulomn4.SelectedItem != null)
                {
                    _match.MovCardsToColumnX(4, 0, (Card)lbxImageCulomn4.SelectedItem);
                }else 
                {
                    throw new Exception("therisn't selected card in listboxs");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
